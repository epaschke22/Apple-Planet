using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WormEffects : MonoBehaviour
{
    [SerializeField] private GlobalData globalData;
    [SerializeField] private GameObject particles;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform planet;
    [SerializeField] private CinemachineSmoothPath path;
    [SerializeField] private CinemachineDollyCart cart;

    private bool _spawnFirstParticles = true;
    private bool _spawnSecondParticles = true;

    void Update()
    {
        if (globalData.isWormAlive)
        {
            if (cart.m_Position > 0.9f && cart.m_Position < 2.8f && _spawnFirstParticles)
            {
                CreateParticles();
                _spawnFirstParticles = false;
            }

            if (cart.m_Position > 1.95f && cart.m_Position < 2.8f && _spawnSecondParticles)
            {
                CreateParticles();
                _spawnSecondParticles = false;
            }

            if (cart.m_Position > 2.8f)
            {
                _spawnFirstParticles = true;
                _spawnSecondParticles = true;
            }
        }
    }

    private void CreateParticles()
	{
        GameObject spawned = Instantiate(particles, spawnPoint.position, spawnPoint.rotation);
        spawned.transform.LookAt(planet);
        spawned.GetComponent<CinemachineImpulseSource>().GenerateImpulse();
        Destroy(spawned, 5);
    }
}
