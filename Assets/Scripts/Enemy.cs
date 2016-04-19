using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    private bool goingRight;
    private bool executeOnce = true; //for Flip() to only execute once
    private float moveSpeed = 6f;

    private Rigidbody2D rb2d;
    private BoxCollider2D thisBox;
    private CircleCollider2D playerBox;

    void Start(){
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        playerBox = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        thisBox = gameObject.GetComponent<BoxCollider2D>();
        health = 100;
    }

    

    void Update(){

        //ignores collision between all enemies
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
            Physics2D.IgnoreCollision(thisBox, obj.GetComponent<BoxCollider2D>());
        }

        //ignores collision between player and enemy
        Physics2D.IgnoreCollision(thisBox, playerBox, true);
        
        MoveControl();
        HealthCheck();
    }

    public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector2 knockBackDir){
        float timer = 0;

        while( knockDur > timer){
            timer += Time.deltaTime;

            if (goingRight){
                rb2d.AddForce(Vector2.left * 5000f);
            }

            else{
                rb2d.AddForce(Vector2.right * 5000f);
            }
        }
        yield return 0;
    }

    public override void MoveControl(){
        if (goingRight){
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }

        else{
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            Flip();
        }
    }

    public override void Flip(){
        if (executeOnce){
            Vector3 theScale = transform.localScale;
            theScale.x *= -1f;
            transform.localScale = theScale;
            executeOnce = false;
        }
    }

    public void SetDirection(bool value){
        goingRight = value;
    }

    public bool GetDirection() { return goingRight; }//returns direction of enemies

    void HealthCheck(){
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}//end class