using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour
{

    // Use this for initialization
    private BoxCollider eggCollider;
    private Rigidbody2D eggProperties;
    private BoxCollider player;//collider for player

    public int eggHealth = 5;// 5 hits to kill egg

    // Use this for initialisation
    void Start()
    {
        eggCollider = gameObject.AddComponent<BoxCollider>();
        eggCollider.size = new Vector2(1, 1);

        eggProperties = gameObject.AddComponent<Rigidbody2D>();
        eggProperties.drag = 1f;
        eggProperties.isKinematic = true;

        GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();

        Physics.IgnoreCollision(eggCollider,player);// ****** ignores collisions with player, need to move egg to lower layer, or player to higher layer

        /* something useful to do for game look / gameplay
         * have egg be on a layer lower than player, so that the egg can still be physical(touchable), 
         * but be passable for the player(player will be able to walk through the egg, instead of jumping over it)
         * or just have physics for only platform below the egg and for enemies, but not player, to enable movement over egg
         * will look into the layers / if/ while statements
         */

    }//end start

    // Update is called once per frame
    void Update()
    {

        //can do health decrease / reset health after powerup is picked up and brought to egg to repair, or after a certian amount of tiem has passed

    }//end update

    void OnTriggerEnter2D(Collider2D col)
    {
        /*

        //if player touches egg,ignore them
        if (col.CompareTag("Player"))
        {
            // can make use of ignorecollison function in unity for this
        }

        //if enemy tocuhes egg, take damage, 1 per second or half second
        if(col.CompareTag("Enemy"))
        {
            //e.g eggHealth--;
        }

        //if hit by arrow take one damage
        if(col.CompareTag("Arrow"))
        {
            
        }

    */
    }//end onentercollision

}//end of script
