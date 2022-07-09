using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GravitySource : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<Collider>().isTrigger = true;
    }

    public Vector3 GetGravityDirection(GravityBody _gravityBody)
    {
        return (transform.position - _gravityBody.transform.position).normalized;
    }
}
