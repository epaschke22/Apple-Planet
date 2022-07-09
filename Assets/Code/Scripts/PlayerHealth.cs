using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GlobalData globalData;

    [SerializeField] private float totalHealth = 100;
    public float health;
    [SerializeField] private Image healthBar;

    [SerializeField] private float pushBack = 1000f;
    private Rigidbody _rb;

    private bool canBeHit = true;

    [SerializeField] private GameObject loseMenu;

    public UnityEvent onDeath;

    void Start()
    {
        globalData.isPlayerAlive = true;
        _rb = GetComponent<Rigidbody>();
        health = totalHealth;
    }

    private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Worm") && canBeHit && globalData.isPlayerAlive && globalData.isWormAlive)
		{
            TakeDamage(25);
            KnockbackPlayer(other.transform.position);
            StartCoroutine(HitDelay());
        }
	}

    private void KnockbackPlayer(Vector3 explosionPoint)
	{
        _rb.AddExplosionForce(pushBack, explosionPoint, 10f);
    }

    IEnumerator HitDelay()
    {
        canBeHit = false;
        yield return new WaitForSeconds(1f);
        canBeHit = true;
    }

    private void TakeDamage(float damage)
	{
        health -= damage;
        if (health <= 0)
		{
            health = 0;
            Death();
        }
        healthBar.fillAmount = health / totalHealth;
    }

    private void Death()
	{
        onDeath.Invoke();
        globalData.isPlayerAlive = false;
        StartCoroutine(RevealGameOver());
    }

    IEnumerator RevealGameOver()
    {
        yield return new WaitForSeconds(2f);
        loseMenu.SetActive(true);
    }
}
