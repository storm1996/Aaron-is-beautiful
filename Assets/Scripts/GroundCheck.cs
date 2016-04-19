using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour{
    private Player player;

    // finds player object for ground checking
    void Start(){ player = gameObject.GetComponentInParent<Player>();}

    // if touching ground colliders, grounded = true, else it's false
    void OnTriggerStay2D(Collider2D col){ player.grounded = true;}
    void OnTriggerExit2D(Collider2D col){ player.grounded = false;}

}//end class
