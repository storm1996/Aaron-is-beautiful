using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    private Player player;
    private BoxCollider2D teleporterBC2D;
    private Rigidbody2D teleporterRB2D;
    private float offset = 3f;
    GameObject[] enemies;

    public virtual void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        teleporterBC2D = gameObject.AddComponent<BoxCollider2D>();
        teleporterRB2D = gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Renderer>().material.color = new Color(155, 0, 155, 0);
        teleporterRB2D.isKinematic = true;
        teleporterBC2D.isTrigger = true;
    }

    void Update(){

        //collisions checking for all enemies on screen
	    foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
            if (teleporterBC2D.IsTouching(obj.GetComponent<BoxCollider2D>())){
                //if touching right teleporter, move to left one
                if (gameObject.tag == "TPRight"){
                    teleporterRB2D = GameObject.FindGameObjectWithTag("TPLeft").GetComponent<Rigidbody2D>();
                    obj.transform.position = new Vector2(teleporterRB2D.transform.position.x + 4f, obj.transform.position.y);
                }

                //if touching left teleporter, move to right one
                if (gameObject.tag == "TPLeft"){
                    teleporterRB2D = GameObject.FindGameObjectWithTag("TPRight").GetComponent<Rigidbody2D>();
                    obj.transform.position = new Vector2(teleporterRB2D.transform.position.x - 4f, obj.transform.position.y);
                }
            }
        }
	}


    void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag("Player")){

            //if touching the right teleporter
            if(gameObject.tag.Equals("TPRight")){

                //brings the player to the left teleporter, gives new position
                teleporterRB2D = GameObject.FindGameObjectWithTag("TPLeft").GetComponent<Rigidbody2D>();
                player.transform.position = new Vector2(teleporterRB2D.transform.position.x + offset, player.transform.position.y);
            }

            //if touching left teleporter
            if (gameObject.tag.Equals("TPLeft")){
                //brings player to the right teleporter, gives new position
                teleporterRB2D = GameObject.FindGameObjectWithTag("TPRight").GetComponent<Rigidbody2D>();
                player.transform.position = new Vector2(teleporterRB2D.transform.position.x - offset, player.transform.position.y);
            }
        }
	}
}//end class