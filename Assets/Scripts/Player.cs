using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    /*
    Shit to do:
        create collider and new script to check if grounded to change animator
    
    Shit to fix:
        Sign off with name at the end
            e.g "fix powerups not hitting - E Money"

        Ideas:
        throw whatever shit you want here

        Alannah: menu system. Later then a pause system?
        Oleg: boundaries and teleportation
        Eamon: Player health
    */
    public float speed = 50f;
    public float maxSpeed = 300f;
    public float jumpForce = 300f;


    public bool grounded;
    public bool canDoubleJump;

    //accessible from other scripts
    private Rigidbody2D rb2d;
    private Rigidbody2D playerRBody;
    private Animator anim;
    private BoxCollider2D playerCollider;

    // Use this for initialization

    void Start () {

        anim = gameObject.GetComponent<Animator>();

        //player properties
        playerRBody = gameObject.AddComponent<Rigidbody2D>();
         playerRBody.gravityScale = 2f;// strength of gravity
         playerRBody.freezeRotation = true; // rotation of player, turned off
         playerRBody.drag = 1f;// friction between air, water, ground, etc
         playerRBody.mass = 1.1f; // player mass

        //player collisions
        playerCollider = gameObject.AddComponent<BoxCollider2D>();
         playerCollider.size = new Vector2(1, 1);


        rb2d = gameObject.GetComponent<Rigidbody2D>();


        GetComponent<Renderer>().material.color = new Color(255, 255, 0, 0);

    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    
    // Update is called once per frame
    void FixedUpdate () {
        /*
        needs fixing
                //adding friction to player so it it doesn't slide
                Vector3 easeVelocity = rb2d.velocity;
                easeVelocity.y = rb2d.velocity.y;
                easeVelocity.x *= 0.75f;

                if (grounded)
                {
                    rb2d.velocity = easeVelocity;
                }

        */

        moveControl();
        jumpControl();
        
        

        //checks if player is air-born
        /*if(playerCollider.IsTouching)
        {
            grounded = true;
        }*/


    }

    
    private void jumpControl()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //will allow to jump if grounded and able to double jump
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpForce);
                canDoubleJump = true;
            }
            else if(canDoubleJump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

                //can set double jump force to be lower than first by dividing
                rb2d.AddForce(Vector2.up * jumpForce);
                canDoubleJump = false;
                
            }


        }
    }

    private void moveControl()
    {
        //x axis. 
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        //limits speed of player according to maxSpeed in both directions
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    //could put in interface e.g. Mario fireball
    public void bounce(float value)
    {
        rb2d.AddForce(Vector2.up * value);
    }
   
}
