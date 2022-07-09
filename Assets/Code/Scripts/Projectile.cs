using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    void Awake()
    {
        Destroy(gameObject, 1);
    }

    public void SetTrajectory(Vector3 targetPosition)
	{
        GetComponent<Rigidbody>().velocity = (targetPosition - transform.position) / 2f;
        transform.LookAt(targetPosition);
    }

    private void Explode()
    {
        GameObject spawned = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(spawned, 1f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
	{
        Explode();
    }

	private void OnTriggerEnter(Collider other)
	{
        Explode();
    }
}
