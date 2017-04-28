using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private Animator animator;

	public float speedFactor = 5f;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float walkingInput = Input.GetAxisRaw("Horizontal");

		animator.SetBool("playerWalking", walkingInput != 0);
		rigidbody.velocity = new Vector2(walkingInput * speedFactor, rigidbody.velocity.y);
	}
}
