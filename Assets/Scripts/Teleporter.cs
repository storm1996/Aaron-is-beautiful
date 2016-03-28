using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    private Player player;
    private BoxCollider2D teleporterBC2D;
    private Rigidbody2D teleporterRB2D;

    // Use this for initialization
    public virtual void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

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
            if(gameObject.tag == "TPRight")
            {
                teleporterRB2D = GameObject.FindGameObjectWithTag("TPLeft").GetComponent<Rigidbody2D>();
                player.transform.position = new Vector2(teleporterRB2D.transform.position.x + 1.5f, player.transform.position.y);
            }
            if (gameObject.tag == "TPLeft")
            {
                teleporterRB2D = GameObject.FindGameObjectWithTag("TPRight").GetComponent<Rigidbody2D>();
                player.transform.position = new Vector2(teleporterRB2D.transform.position.x - 1.5f, player.transform.position.y);
            }
        }
    }
}
