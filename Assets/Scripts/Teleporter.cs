using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    private Player player;
    private EnemyPatrol enemy;
    private BoxCollider2D teleporterBC2D;
    private Rigidbody2D teleporterRB2D;
    private float offset = 3f;

    // Use this for initialization
    public virtual void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyPatrol>();

        teleporterBC2D = gameObject.AddComponent<BoxCollider2D>();
        teleporterRB2D = gameObject.AddComponent<Rigidbody2D>();

        GetComponent<Renderer>().material.color = new Color(155, 0, 155, 0);
        teleporterRB2D.isKinematic = true;
        teleporterBC2D.isTrigger = true;
        
    }

    // Update is called once per frame
    void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //if touching the right teleporter
            if(gameObject.tag.Equals("TPRight"))
            {
                //brings the player to the left teleporter, gives new position
                teleporterRB2D = GameObject.FindGameObjectWithTag("TPLeft").GetComponent<Rigidbody2D>();
                player.transform.position = new Vector2(teleporterRB2D.transform.position.x + offset, player.transform.position.y);
            }

            //if touching left teleporter
            if (gameObject.tag.Equals("TPLeft"))
            {
                //brings player to the right teleporter, gives new position
                teleporterRB2D = GameObject.FindGameObjectWithTag("TPRight").GetComponent<Rigidbody2D>();
                player.transform.position = new Vector2(teleporterRB2D.transform.position.x - offset, player.transform.position.y);
            }
        }

        //checks if enemy enters the portals
        if (col.CompareTag("Enemy"))
        {
            //if touching the right teleporter
            if (gameObject.tag == "TPRight")
            {
                //brings the player to the left teleporter, gives new position
                teleporterRB2D = GameObject.FindGameObjectWithTag("TPLeft").GetComponent<Rigidbody2D>();
                enemy.transform.position = new Vector2(teleporterRB2D.transform.position.x + 3f, enemy.transform.position.y);
            }

            //if touching left teleporter
            if (gameObject.tag == "TPLeft")
            {
                //brings player to the right teleporter, gives new position
                teleporterRB2D = GameObject.FindGameObjectWithTag("TPRight").GetComponent<Rigidbody2D>();
                enemy.transform.position = new Vector2(teleporterRB2D.transform.position.x - 3f, enemy.transform.position.y);
            }
        }
    }
}
