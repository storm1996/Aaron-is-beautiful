using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour
{

    // Use this for initialization
    public BoxCollider2D eggCollider;
    public Rigidbody2D eggProperties;
    public BoxCollider2D player;//collider for player

    public int eggHealth;// 5 hits to kill egg
    public bool hit;

    // Use this for initialisation
    void Start()
    {
        hit = true;
        eggHealth = 5;
        eggCollider = gameObject.AddComponent<BoxCollider2D>();
        eggCollider.size = new Vector2(1, 1);

        eggProperties = gameObject.AddComponent<Rigidbody2D>();
        eggProperties.drag = 1f;
        eggProperties.isKinematic = true;

        //GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();

        Physics2D.IgnoreLayerCollision(8,9,true); //ignores player and egg layer collisions
        //Physics2D.IgnoreCollision(player,eggCollider, true);
        //Debug.Log(Physics2D.GetIgnoreCollision(player,eggCollider));

        // ****** ignores collisions with player, need to move egg to lower layer, or player to higher layer

        /* something useful to do for game look / gameplay
         * have egg be on a layer lower than player, so that the egg can still be physical(touchable), 
         * but be passable for the player(player will be able to walk through the egg, instead of jumping over it)
         * or just have physics for only platform below the egg and for enemies, but not player, to enable movement over egg
         * will look into the layers / if/ while statements
         */

    }//end start

    // Update is called once per frame
    public void Update()
    {

        //can do health decrease / reset health after powerup is picked up and brought to egg to repair, or after a certian amount of tiem has passed


        /*will run a loop of some sort that will check that egg is not dead,
         *if egg is dead (eggHealth = 0), then the bool GameOver will be true, and you will be kicked to the main menu/game over screen
         *which has options to restart or go to main menu, or to exit the game altogether
        */
        /*while(eggHealth > 0)
        {
            GameOver = false;
        }*/

    }//end update


    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hit something");

        //if player touches egg,ignore them

        /*Found bug, player doesn't get instantiated for some reason, where its tag "Player" or its boxcollider is not properly added 
         *into the code / variables 
         */


        if (col.gameObject.tag == "Enemy" && hit)
        {
            Debug.Log("hit egg");
            hit = false;
            eggHealth--;
            Invoke("EggHittable", 1);
        }

        //if enemy touches egg and hit is true, take damage, 1 per second
        /*else if(col.CompareTag("Enemy") && hit)
        {
            hit = false;
            eggHealth--;
            Invoke("EggHittable",1);
        }*/

        //if hit by arrow and hit is true, take one damage per 1 second delay
        /*else if(col.CompareTag("Arrow") && hit)
        {
            hit = false;
            eggHealth--;
            Invoke("EggHittable",1);
        }*/
    }//end onentercollision

    //let's enemies deal damage to egg
    public void EggHittable()
    {
        hit = true;
    }

}//end of script
