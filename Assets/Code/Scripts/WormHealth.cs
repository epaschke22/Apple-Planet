using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WormHealth : MonoBehaviour
{
    [SerializeField] private GlobalData globalData;

    [SerializeField] private float totalHealth = 100;
    private float health;

    [SerializeField] private Image healthBar;
    [SerializeField] private Material wormMat;

    [SerializeField] private GameObject winMenu;

    public UnityEvent onTakeDamage;
    public UnityEvent onWormDeath;

	private void Start()
	{
        globalData.isWormAlive = true;
        health = totalHealth;
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Projectile") && globalData.isWormAlive)
		{
            TakeDamage(1);
            StartCoroutine(FlashDamage());
        }
	}

    IEnumerator FlashDamage()
	{
        wormMat.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        wormMat.color = Color.white;
    }

    private void TakeDamage(int damage)
	{
        health -= damage;
        onTakeDamage.Invoke();
        if (health <= 0)
		{
            health = 0;
            WormDeath();
        }
        healthBar.fillAmount = health / totalHealth;
    }

    private void WormDeath()
	{
        globalData.isWormAlive = false;
        onWormDeath.Invoke();
        StartCoroutine(RevealWinScreen());
    }

    IEnumerator RevealWinScreen()
    {
        yield return new WaitForSeconds(2f);
        winMenu.SetActive(true);
    }
}
