using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	private Rigidbody _rigidbody;
	[SerializeField] private float _speed = 15.0f;
	[SerializeField] private float _jumpForce;
	[SerializeField] private LayerMask _groundLayer;
	[SerializeField] private Transform _groundCheck;
	private bool _pressedJump = false;
	private bool _canJump = false;
	private bool grounded;
	private float facing;
	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update() {
		grounded = Physics.Linecast(transform.position, _groundCheck.position, _groundLayer);
		Debug.DrawLine(transform.position, _groundCheck.position, Color.red);
		if(grounded){
			_canJump = true;
		}else{
			_canJump = false;
		}
		if(Input.GetKeyDown(KeyCode.Space) && _canJump){
			_canJump = false;
			_pressedJump = true;
		}
	}

	private void FixedUpdate()
	{
		if(_pressedJump){
			Jump();
			_pressedJump = false;
		}

		Vector2 _movement = GetMovement();
		_rigidbody.velocity += (Vector3)_movement * _speed;
		if (_movement.x < 0)
		{
			_rigidbody.rotation = Quaternion.Euler(0, 180, 0); 
		}
		else
		{
			_rigidbody.rotation = Quaternion.Euler(0, 0, 0); 
		}
		

		if (!grounded)
		{
			_rigidbody.AddForce(Physics.gravity * 1.5f, ForceMode.Acceleration);
		}
	}

	private Vector2 GetMovement(){
		float _horizontalAxis = Input.GetAxisRaw("Horizontal"); //get the left and right input(A-D or LeftArrow-RightArrow)
		Vector2 _movement =  new Vector2(_horizontalAxis , 0);
		if(_movement.magnitude > 1){
			_movement.Normalize();
		}
		return _movement;
	}
	private void Jump(){
		_rigidbody.AddForce(Vector3.up  * _jumpForce, ForceMode.Acceleration);
	}
}
