using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

    private Player player;
    //private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //collider = gameObject.GetComponent<BoxCollider2D>();

        //collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	    
    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(player.Knockback(0.02f, 500f, player.transform.position));
        }
        
    }
}
