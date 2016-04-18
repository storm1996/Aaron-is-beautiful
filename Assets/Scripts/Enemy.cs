using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    private bool facingRight;
    private Rigidbody2D rb2d;

    private BoxCollider2D thisBox;
    private CircleCollider2D playerBox;

    private bool executeOnce = true;

    private float moveSpeed = 6f;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
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

    public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector2 knockBackDir)
    {
        float timer = 0;
        while( knockDur > timer)
        {
            timer += Time.deltaTime;

            if (facingRight)
            {
                rb2d.AddForce(Vector2.left * 5000f);
                //rb2d.AddForce(new Vector3(knockBackDir.x * -5000f, knockBackDir.y, transform.position.z));
            }
            else
            {
                //rb2d.AddForce(new Vector3(knockBackDir.x * 5000f, knockBackDir.y, transform.position.z));
                rb2d.AddForce(Vector2.right * 5000f);
            }
        }

        

        yield return 0;
    }


    void Flip()
    {
        //facingRight = !facingRight;
        
        if (executeOnce)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1f;
            //theScale.y = 0.3f;
            transform.localScale = theScale;
            executeOnce = false;
        }
    }

    public void SetDirection(bool value)
    {
        facingRight = value;
    }

    public bool GetDirection()
    {
        return facingRight;
    }

}