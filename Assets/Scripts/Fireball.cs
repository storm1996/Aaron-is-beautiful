﻿/*
HOLDS FIREBALL MOVEMENT AND COLLISION CODE
*/
using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public Rigidbody2D rb2d;
    private BoxCollider2D boxCollider;

    private float speed = 1000f;

    //creates fireball and its collider
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    //checks if fireball is touching any enemies, destroys them if they are, and explodes
    void Update(){
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
            if (boxCollider.IsTouching(obj.GetComponent<BoxCollider2D>())){
                Player.explode();
                Destroy(gameObject);
                obj.GetComponent<Enemy>().Damage(50);
            }
        }
    }

    
    //fires
    public void Fire(string direction){
        if (direction.Equals("Left")){
            rb2d.AddForce(Vector2.left * speed);
            rb2d.transform.localScale = new Vector2(-1, 1);
        }
        else if (direction.Equals("Right")){ rb2d.AddForce(Vector2.right * speed);}
    }

    // if fireball hits a platform or the border, it is destroyed
    public void OnTriggerEnter2D(Collider2D col){ if (col.CompareTag("Border") || col.CompareTag("Ground")){ Destroy(gameObject);}}

}//end class
