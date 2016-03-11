using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
	}
	
	// Update is called once per frame
	void Update () {
	    
    
	}
   
    void OnTriggerEnter2D(Collider2D col)
    {

        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //check(col);
        if (col.CompareTag("Player"))
        {
            //reduce health of player
            player.Damage(1);
            //StartCoroutine does something
            StartCoroutine(player.Knockback(0.02f, 500f, player.transform.position));

        }
    }

    private void check(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //reduce health of player
            player.Damage(1);
            //StartCoroutine does something
            StartCoroutine(player.Knockback(0.02f, 500f, player.transform.position));

        }
    }
}
