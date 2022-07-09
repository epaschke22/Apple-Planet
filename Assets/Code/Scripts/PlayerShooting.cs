using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GlobalData globalData;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera cam;

    private Vector3 aimPoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && globalData.isPlayerAlive)
		{            
            GameObject spawned = Instantiate(bullet, transform.position, transform.rotation);


            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            Vector3 targetPoint = ray.GetPoint(rayLength);

            if (Physics.Raycast(ray, out hit, rayLength, layerMask, QueryTriggerInteraction.Collide))
			{
                targetPoint = hit.point;
            }
            
            if (spawned.TryGetComponent(out Projectile projectile))
			{
                projectile.SetTrajectory(targetPoint);
			}
        }
        Ray ray1 = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray1.origin, ray1.direction * rayLength, Color.blue);
    }
}
