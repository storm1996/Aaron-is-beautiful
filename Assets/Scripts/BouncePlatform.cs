using UnityEngine;
using System.Collections;

public class BouncePlatform : MonoBehaviour {
    /*
    can change grounded/double jump fields to account for inconsistenciess
    */


    private Player player;
   
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        float b = 500f;

        if (col.CompareTag("Player"))
        {
            //calling method inside class. Probably better from OOP principles
            player.bounce(b);
        }


    }


    
}
