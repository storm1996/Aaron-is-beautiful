using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    /*
    Shit to do:
        create collider and new script to check if grounded to change animator
    */
    public float speed = 50f;
    public float maxSpeed = 300f;
    public float jumpForce = 300f;


    public bool grounded;
    public bool canDoubleJump;

    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<Animator>();

        //player collisions
        Rigidbody2D playerRBody = gameObject.AddComponent<Rigidbody2D>();
         playerRBody.gravityScale = 2f;// strength of gravity
         playerRBody.angularDrag = 12f; // rotation of player
         playerRBody.drag = 1f;// friction between air, water, ground, etc
         playerRBody.mass = 1.1f; // player mass


        rb2d = gameObject.GetComponent<Rigidbody2D>();


        GetComponent<Renderer>().material.color = new Color(255, 255, 0, 0);


        BoxCollider2D playerCollider = gameObject.AddComponent<BoxCollider2D>();
          playerCollider.size = new Vector2(1, 1);

        
    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    
    // Update is called once per frame
    void FixedUpdate () {
        //adding friction to player so it it doesn't slide
       /* Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.x *= 0.10f;

        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }
        */


        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        //limits speed of player according to maxSpeed
        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        //jumping
        if (Input.GetButtonDown("Jump") )
        {
            
           if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpForce);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

                    //can set double jump force to be lower than first by dividing
                    rb2d.AddForce(Vector2.up * jumpForce);
                    canDoubleJump = false;
                }
            }
        
            
        }

        //checks if player is air-born
        /*if(playerCollider.IsTouching)
        {
            grounded = true;
        }*/


    }
}
