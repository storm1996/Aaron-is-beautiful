using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public bool facingRight;
    private Rigidbody2D rb2d;

    private BoxCollider2D thisBox;
    private CircleCollider2D playerBox;

    private float moveSpeed = 6f;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        playerBox = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        thisBox = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //ignores collision between multiple enemies
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Physics2D.IgnoreCollision(thisBox, obj.GetComponent<BoxCollider2D>());
        }

        //ignores collision between player and enemies
        Physics2D.IgnoreCollision(thisBox, playerBox, true);

        if (facingRight)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            Flip();
        }


    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1f;
        //theScale.y = 0.3f;
        transform.localScale = theScale;
    }

}