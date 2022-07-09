using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GlobalData globalData;
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float jumpPower = 20;
    [SerializeField] private float turnSpeed = 1500f;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private float _groundCheckRadius = 0.5f;
    private Vector3 _moveDirection;
    private Rigidbody _rb;
    private GravityBody _gravityBody;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _gravityBody = GetComponent<GravityBody>();
    }

    void Update()
    {
        if (globalData.isPlayerAlive)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;

            bool isGrounded = Physics.CheckSphere(groundCheck.position, _groundCheckRadius, groundMask);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                _rb.AddForce(-_gravityBody.GravityDirection * jumpPower, ForceMode.Impulse);
            }
        }
		else
		{
            _moveDirection = Vector3.zero;
        }
    }

	private void FixedUpdate()
	{
        if (_moveDirection.magnitude > 0.1f)
		{
			Vector3 direction = transform.forward * _moveDirection.z;
			_rb.MovePosition(_rb.position + direction * (moveSpeed * Time.fixedDeltaTime));

			Quaternion rightDirection = Quaternion.Euler(0f, _moveDirection.x * (turnSpeed * Time.fixedDeltaTime), 0f);
			Quaternion newRotation = Quaternion.Slerp(_rb.rotation, _rb.rotation * rightDirection, Time.fixedDeltaTime * 3f);
			_rb.MoveRotation(newRotation);
		}
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, _groundCheckRadius);
	}
}
