using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour
{

    // Use this for initialization
    public BoxCollider2D eggCollider;
    public Rigidbody2D eggProperties;
    //public CircleCollider2D player;//collider for player

    public int eggHealth;// 5 hits to kill egg
    public bool hit;

    //audio
    public AudioSource sound;// use sound source for the object
    public AudioClip jump;
    

    // Use this for initialisation
    void Start()
    {
        
        /* ****** just for testing sound 
         * can make code better - multiple sounds
         * have it add in all sounds at start of game(?)
         */
        //loads in jump sound that is attached to egg
        sound = GetComponent<AudioSource>();

        hit = true;
        eggHealth = 5;
        eggCollider = gameObject.AddComponent<BoxCollider2D>();
        eggCollider.size = new Vector2(1, 1);

        eggProperties = gameObject.AddComponent<Rigidbody2D>();
        eggProperties.drag = 1f;
        eggProperties.isKinematic = true;

        //GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);

        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();

        Physics2D.IgnoreLayerCollision(8,9,true); //ignores player and egg layer collisions - layer 8 and 9
        
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

        if (col.gameObject.tag == "Enemy" && hit)
        {
            Debug.Log("enemy hit egg");
            sound.PlayOneShot(jump);
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
        else if(col.gameObject.tag == "Arrow" && hit)
        {
            Debug.Log("arrow hit egg");
            sound.PlayOneShot(jump);
            hit = false;
            eggHealth--;
            Invoke("EggHittable",1);
        }
    }//end onentercollision

    //let's enemies deal damage to egg
    public void EggHittable()
    {
        hit = true;
    }

}//end of script
