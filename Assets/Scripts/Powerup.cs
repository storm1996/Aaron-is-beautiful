using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

    private Player player;

	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
             
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        { 
            //destroys current gameObject during collision with player
            Destroy(gameObject);
            player.healthPowerUp(100);
        }
    }
}
