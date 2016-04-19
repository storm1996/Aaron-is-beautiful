using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : Character {
    
    public float maxSpeed = 300f;// max speed you can go left or right
    public float jumpForce;// jump power in y direction
    public int score; //maybe put this in own game control script

	public Transform groundCheck;
	public float groundCheckRadius; 
	public LayerMask whatIsGround; 
	public bool grounded;// player touching ground
	public bool shooting;
	public bool doubleJumped;// checks if player jumped twice
    private Rigidbody2D rb2d;
    private Rigidbody2D playerRBody;
    private Animator anim;
    public static BoxCollider2D playerCollider;
    private Transform newPosition;
    public static AudioClip[] sounds;//holds sounds used by player
    public GameObject fireballPrefab;// fireball asset
    public bool facingRight;//direction player is facing

    private float timeBetweenShots = 0.14f;
    private float timestamp;
    void Start () {

        anim = gameObject.GetComponent<Animator>();

        //player properties
        playerRBody = gameObject.AddComponent<Rigidbody2D>();
        playerRBody.gravityScale = 5f;// strength of gravity
        playerRBody.freezeRotation = true; // rotation of player, turned off
        playerRBody.drag = 0.5f;// friction between air, water, ground, etc
        playerRBody.mass = 1f; // player mass
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        health = 100;
        speed = 50f;
        jumpForce = 22f;//jump power
        facingRight = true;
        
        fireballPrefab = Resources.Load("Fireball") as GameObject;
        jumpForce = 22f;// jump power
        facingRight = true;// direction of player

        fireballPrefab = Resources.Load("Fireball") as GameObject;// loads in fireball asset 

        sounds = new AudioClip[]{
            Resources.Load("Sound_Jump") as AudioClip,
            Resources.Load("Sound_Fireball") as AudioClip,
            Resources.Load("Sound_Explosion") as AudioClip,
        };
    }
 
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        float h = Input.GetAxis("Horizontal");

        // controls player movement and jumping
        MoveControl();
        FireControl();
        JumpControl();

        anim.ResetTrigger("shooting");

        // checks where player is facing, flips their sprite to opposite direction
        if (h > 0 && !facingRight) { Flip(); }
        else if (h < 0 && facingRight) { Flip(); }

        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    // adds speed to player direction, moves player more or less
    public override void MoveControl()
    {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);

        // limits speed of player according to maxSpeed in both directions, based on x-axis
        if (rb2d.velocity.x > maxSpeed) { rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y); }
        if (rb2d.velocity.x < -maxSpeed) { rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y); }
    }

    void JumpControl(){
        //checks if grounded for double jump
        if (grounded)
        {
            doubleJumped = false;
            anim.SetBool("Grounded", grounded);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
            AudioSource.PlayClipAtPoint(sounds[0], Vector2.zero);// plays jumping sound
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            AudioSource.PlayClipAtPoint(sounds[0], Vector2.zero);// plays jumping sound
            doubleJumped = true;// player has jumped twice if true
        }

        if (!grounded) { anim.SetBool("Grounded", !grounded); }// jumping animation
    }

    void FireControl()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= timestamp)
        {
            anim.SetTrigger("shooting");

            //creates fireball if facing right or left
            if (facingRight) { CreateFireball("Right"); }
            else if (!facingRight) { CreateFireball("Left"); }

            timestamp = Time.time + timeBetweenShots;
        }
    }

    // creates new instance of fireball everytime player casts it (presses left mouse button)
    public void CreateFireball(string direction){
        float offset = 1f;
        Vector2 newPosition;
        GameObject newFireball;
        
        // creates a fireball going right
        if (direction.Equals("Right")){
            newPosition = new Vector3(transform.position.x + offset, transform.position.y);
            newFireball = (GameObject)Instantiate(fireballPrefab, newPosition, Quaternion.identity);

            //shoots fireball in direction
            ShootFireball(newFireball, newPosition, direction);
        }

        // creates a fireball going left
        else if (direction.Equals("Left")){
            newPosition = new Vector3(transform.position.x - offset, transform.position.y);
            newFireball = (GameObject)Instantiate(fireballPrefab, newPosition, Quaternion.identity);

            ShootFireball(newFireball, newPosition, direction);
        }
    }

    //takes in parameters from instantiated fireball above and shoots it. Avoids code duplication
    void ShootFireball(GameObject fireball, Vector2 position, string direction)
    {
        Fireball fireballScript;

        fireballScript = fireball.GetComponent<Fireball>();
        fireballScript.Fire(direction);
        AudioSource.PlayClipAtPoint(sounds[1], Vector3.zero);// plays fireball cast sound
    }
    
    // flips player sprite depending on where it's facing
    public override void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    // increases player health or score based on the powerup they touch
    public void PowerUp(string type, int value){
        if (type.Equals("Health")){ health += value;}
        else if (type.Equals("Score")){ health += score;}
    }

    // player jumps with in y direction with jumpForce
	public void Jump(){ GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);}


    public static void explode() { AudioSource.PlayClipAtPoint(sounds[2], Vector2.zero); }// plays explosion sounds firebal hits an enemy

}//end class
