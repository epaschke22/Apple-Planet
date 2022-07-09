using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravitySource gravitySource;
    public Vector3 GravityDirection;

    private static float GRAVITY_FORCE = 800;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        GravityDirection = gravitySource.GetGravityDirection(this).normalized;
        _rigidbody.AddForce(GravityDirection * (GRAVITY_FORCE * Time.fixedDeltaTime), ForceMode.Acceleration);

        Quaternion upRotation = Quaternion.FromToRotation(transform.up, -GravityDirection);
        Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, upRotation * _rigidbody.rotation, Time.fixedDeltaTime * 3f); ;
        _rigidbody.MoveRotation(newRotation);
    }
}
