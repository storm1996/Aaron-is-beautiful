using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
    /*
    Shit to do:
        create collider and new script to check if grounded to change animator

        create function to get/set components
    
    Shit to fix:
        Sign off with name at the end
            e.g "fix powerups not hitting - E Money"

        irregular bouncing when on bouncy platform - E Dog

        Ideas:
        throw whatever shit you want here

        Powerups regenerate after time period or destroys itself after a while.

        Alannah: menu system. Later then a pause system?
        Oleg: boundaries and teleportation
        Eamon: Player health
    */
    public float speed = 50f;
    public float maxSpeed = 300f;
    public float jumpForce = 300f;

    public int health = 100;
    public int score; //maybe put this in own game control script

    public bool grounded;
    public bool canDoubleJump;

    //accessible from other scripts
    private Rigidbody2D rb2d;
    private Rigidbody2D playerRBody;
    private Animator anim;
    public static BoxCollider2D playerCollider;
    private Transform newPosition;

    public GameObject arrow;
    public GameObject fireballPrefab;

    private bool facingRight;

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

        arrow = Resources.Load("Arrow") as GameObject;
        fireballPrefab = Resources.Load("Fireball") as GameObject;

    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        //shoots fireball depending where player is facing
        if (Input.GetButtonDown("Fire1"))
        { 
            if(facingRight)
            {
                //optimise this
                Vector3 newPosition = new Vector3(transform.position.x + 1f, transform.position.y);
                //change this
                GameObject newArrow = (GameObject)Instantiate(arrow, newPosition, Quaternion.identity);
                Rigidbody2D arrowRB2D = newArrow.GetComponent<Rigidbody2D>();
                arrowRB2D.AddForce(Vector2.right * 500);
                arrowRB2D.AddForce(Vector2.up * 500);

                CreateFireball("Right");

            }
            else if(!facingRight)
            {
                //optimise this
                Vector3 newPosition = new Vector3(transform.position.x - 1f, transform.position.y);
                GameObject newArrow = (GameObject)Instantiate(arrow, newPosition, Quaternion.identity);
                Rigidbody2D arrowRB2D = newArrow.GetComponent<Rigidbody2D>();
                arrowRB2D.AddForce(Vector2.left * 500);
                arrowRB2D.AddForce(Vector2.up * 500);

                CreateFireball("Left");
            }

        }
    }

    public void CreateFireball(string direction)
    {
        float offset = 1f;
        Vector3 newPosition;
        GameObject newFireball;
        Fireball fireballScript;
        
        if (direction.Equals("Right"))
        {
            newPosition = new Vector3(transform.position.x + offset, transform.position.y);
            newFireball = (GameObject)Instantiate(fireballPrefab, newPosition, Quaternion.identity);
            fireballScript = newFireball.GetComponent<Fireball>();
            fireballScript.Fire(direction);
        }
        else if (direction.Equals("Left"))
        {
            newPosition = new Vector3(transform.position.x - offset, transform.position.y);
            newFireball = (GameObject)Instantiate(fireballPrefab, newPosition, Quaternion.identity);
            fireballScript = newFireball.GetComponent<Fireball>();
            fireballScript.Fire(direction);
        }

    }

    // Update is called once per frame
    void FixedUpdate () {

        float h = Input.GetAxis("Horizontal");

        //controls player movement and jumping
        MoveControl();
        JumpControl();

        //checks where player is facing
        if (h > 0 && !facingRight)
        {
            Flip();
        }           
        else if (h < 0 && facingRight)
        {
            Flip();
        }
    }

    //flips player sprite depending on where it's facing
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //takes away health from player
    public void Damage(int damage)
    {
        health -= damage;
    }

    
    private void JumpControl()
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

    private void MoveControl()
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
    public void Bounce(float value)
    {
        rb2d.AddForce(Vector2.up * value);
    }

    //health powerup
    public void HealthPowerUp(int value)
    {
        health += value;
    }

    //health powerup
    public void ScorePowerUp(int value)
    {
        score += value;
    }

    //I don't know what IEnumerator does. 
    //Has a knock back effect when it hits the spike
    public IEnumerator Knockback(float knockDur, float knockBackPwr, Vector3 knockBackDir)
    {
        float timer = 0;

        while(knockDur > timer)
        {
            timer += Time.deltaTime;

            //if player moving right
            if(Input.GetAxis("Horizontal") > 0.01f)
            {
                rb2d.AddForce(new Vector3(knockBackDir.x * -250f, knockBackDir.y, transform.position.z));
            }
            //player moving left
            else if(Input.GetAxis("Horizontal") < 0.01f)
            {
                rb2d.AddForce(new Vector3(knockBackDir.x * 250f, knockBackDir.y, transform.position.z));
            }
            
        }

        yield return 0;
    }

}
