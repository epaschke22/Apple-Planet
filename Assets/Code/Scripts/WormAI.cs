using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WormAI : MonoBehaviour
{
    [SerializeField] private GlobalData globalData;
    [SerializeField] private Transform player;
    [SerializeField] private CinemachineSmoothPath path;
    [SerializeField] private CinemachineDollyCart cart;

	private void Start()
	{
        cart.m_Speed = 0;
        StartCoroutine(DeplayStart());
    }

	void Update()
    {
        if (globalData.isPlayerAlive)
		{
            if (cart.m_Position < 0.8f)
            {
                path.m_Waypoints[1].position = player.position;
            }

            if (cart.m_Position > 1f && cart.m_Position < 1.8f)
            {
                path.m_Waypoints[2].position = player.position;
            }
        }

        if (!globalData.isWormAlive)
		{
            cart.m_Speed = 0;
		}

        path.InvalidateDistanceCache();
    }

    IEnumerator DeplayStart()
	{
        yield return new WaitForSeconds(2f);
        cart.m_Speed = 0.5f;
    }
}
