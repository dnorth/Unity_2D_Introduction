using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedFactor = 5.0f;
    private float jumpFactor = 300;
    private bool facingRight = true;
    private bool grounded = true;
    private Animator animator;
    private Rigidbody2D rigidBody;

	void Start ()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();    	
	}
	void Update()
	{
	 float walkingInput = Input.GetAxis("Horizontal");
         float jumpingInput = Input.GetAxis("Vertical");
	}
	
	void FixedUpdate () {
		
        animator.SetBool("playerWalking", walkingInput != 0);
        animator.SetBool("playerJumping", !grounded);

        rigidBody.velocity = new Vector2(walkingInput * speedFactor, rigidBody.velocity.y);

        if(jumpingInput > 0 && grounded)
        {
            rigidBody.AddForce(Vector2.up * jumpFactor);
            grounded = false;
        }

        if (walkingInput > 0 && !facingRight)
        {
            FlipFacing();
        }
        else if(walkingInput < 0 && facingRight)
        {
            FlipFacing();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        grounded = true;
    }

    void FlipFacing()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }
}
