using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;
    private Animator animator;
    private Rigidbody2D rigidBody;

	void Start ()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();    	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float walkingInput = Input.GetAxisRaw("Horizontal");
        if (walkingInput != 0)
        {
            animator.SetBool("playerWalking", true);
            rigidBody.velocity = new Vector2(walkingInput * speed, rigidBody.position.y);
        }
        else 
        {
            animator.SetBool("playerWalking", false);
            rigidBody.velocity = new Vector2(0,0);
        }
    }
}
