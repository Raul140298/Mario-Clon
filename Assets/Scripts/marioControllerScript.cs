using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marioControllerScript : MonoBehaviour
{
    public float jumpHeight;
    public static bool isJumping = false;
    public float acceleration, speed;
    public float horizontal, velocity;
    public Rigidbody2D rigidBody;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        manageMovement();
        manageJump();
    }

    void FixedUpdate()
	{
        rigidBody.velocity = new Vector2((Mathf.Abs(velocity) < 0.01f ? 0.0f : velocity) * speed, rigidBody.velocity.y);
    }

    void manageMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal < 0)
		{
            animator.SetFloat("ejeX", -1);
		}
        if (horizontal > 0)
        {
            animator.SetFloat("ejeX", 1);
        }
        if (horizontal != 0f)
        {
            animator.SetBool("walking", true);
            velocity = Mathf.Clamp(velocity + horizontal * acceleration * Time.deltaTime, -1f, 1f);
        }
        else
        {
            animator.SetBool("walking", false);
            velocity -= velocity * acceleration * Time.deltaTime;
        }
    }

    void manageJump()
    {
        if (Input.GetButtonDown("Jump") && (isJumping == false))
        {
            SoundSystemScript.PlaySound("Sound_jump");
            rigidBody.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("ground"))
        {
            isJumping = false;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("ground"))
        {
            isJumping = true;
        }
    }
}
