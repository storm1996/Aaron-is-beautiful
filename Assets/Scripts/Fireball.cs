using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public Rigidbody2D rb2d;
    
    private float speed = 1000f;

	// Use this for initialization
	void Start () {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
      
    }

    public void fire(string direction)
    {
        if (direction.Equals("Left"))
        {
            rb2d.AddForce(Vector2.left * speed);
        }
        else if (direction.Equals("Right"))
        {
            rb2d.AddForce(Vector2.right * speed);
        }
    }
    
}
