using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidBody;

	void Start ()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();    	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal") * 2.0f, Input.GetAxisRaw("Vertical"));

        if (move != Vector2.zero)
        {
            rigidBody.AddForce(move);
            animator.SetTrigger("playerWalking");
        }

    }
}
