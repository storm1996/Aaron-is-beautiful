using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : Character {
    
    public float maxSpeed = 300f;
    public float jumpForce;
    
    public int score; //maybe put this in own game control script

	public Transform groundCheck;
	public float groundCheckRadius; 
	public LayerMask whatIsGround; 
	public bool grounded; 
	public bool shooting; 

	public bool doubleJumped;

    //accessible from other scripts
    private Rigidbody2D rb2d;
    private Rigidbody2D playerRBody;
    private Animator anim;
	//private Animator anim2;
    public static BoxCollider2D playerCollider;
    private Transform newPosition;

    public GameObject arrow;
    public GameObject fireballPrefab;

    public static AudioClip[] sounds;//holds sounds used by player

    public bool facingRight;

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
        arrow = Resources.Load("Arrow") as GameObject;
        health = 100;
        speed = 50f;
        jumpForce = 22f;//jump power
        facingRight = true;
        
        fireballPrefab = Resources.Load("Fireball") as GameObject;

        sounds = new AudioClip[]{
            Resources.Load("Sound_Jump") as AudioClip,
            Resources.Load("Sound_Fireball") as AudioClip,
            Resources.Load("Sound_Explosion") as AudioClip,
        };
    }

    public static void explode() {AudioSource.PlayClipAtPoint(sounds[2], Vector2.zero);}// plays explosion sounds firebal hits an enemy

    
    void Update(){
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        

		// Just flips the way he's facing depending on what way he's moving
		if(GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}

        else if(GetComponent<Rigidbody2D> ().velocity.x < 0){
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		if (grounded){
			doubleJumped = false;
			anim.SetBool ("Grounded", grounded);
		}

		if (Input.GetKeyDown (KeyCode.Space) && grounded){
			Jump ();
            AudioSource.PlayClipAtPoint(sounds[0], Vector2.zero);
        }


		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded){
			Jump ();
            AudioSource.PlayClipAtPoint(sounds[0], Vector2.zero);//plays jumping sound
            doubleJumped = true;
		}

		if (!grounded) {
			anim.SetBool ("Grounded", !grounded);
		}
	}

    public void CreateFireball(string direction){
        float offset = 1f;
        Vector3 newPosition;
        GameObject newFireball;
        Fireball fireballScript;
        
        if (direction.Equals("Right")){
            newPosition = new Vector3(transform.position.x + offset, transform.position.y);
            newFireball = (GameObject)Instantiate(fireballPrefab, newPosition, Quaternion.identity);
            fireballScript = newFireball.GetComponent<Fireball>();
            fireballScript.Fire(direction);
            AudioSource.PlayClipAtPoint(sounds[1], Vector3.zero);
        }

        else if (direction.Equals("Left")){
            newPosition = new Vector3(transform.position.x - offset, transform.position.y);
            newFireball = (GameObject)Instantiate(fireballPrefab, newPosition, Quaternion.identity);
            fireballScript = newFireball.GetComponent<Fireball>();
            fireballScript.Fire(direction);
            AudioSource.PlayClipAtPoint(sounds[1], Vector3.zero);
        }
    }

    void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
        float h = Input.GetAxis("Horizontal");

        //controls player movement and jumping
        MoveControl();

        //checks where player is facing
        if (h > 0 && !facingRight){
            Flip();
        }           
        else if (h < 0 && facingRight){
            Flip();
        }
        
        if (Input.GetButtonDown("Fire1") && Time.time >= timestamp)
        {

            anim.SetTrigger("shooting");

            if (facingRight)
            {
                CreateFireball("Right");
            }

            else if (!facingRight)
            {
                CreateFireball("Left");
            }

            timestamp = Time.time + timeBetweenShots;
        }
        

            anim.ResetTrigger("shooting");
    }

    //flips player sprite depending on where it's facing
    public override void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public override void MoveControl(){
       
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);

        //limits speed of player according to maxSpeed in both directions
        if (rb2d.velocity.x > maxSpeed){
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed){
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    public void PowerUp(string type, int value){

        if (type.Equals("Health")){
            health += value;
        }

        else if (type.Equals("Score")){
            health += score;
        }
    }

    //health powerup
    public void HealthPowerUp(int value){
        health += value;
    }

    //health powerup
    public void ScorePowerUp(int value){
        score += value;
    }

	public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x, jumpForce);
	}
}//end class
