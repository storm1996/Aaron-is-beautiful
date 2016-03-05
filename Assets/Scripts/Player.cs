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

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        Rigidbody2D playerRBody = gameObject.AddComponent<Rigidbody2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();


        GetComponent<Renderer>().material.color = new Color(255, 255, 0, 0);
        BoxCollider2D playerCollider = gameObject.AddComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        

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
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }

    }
}
