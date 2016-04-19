

using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour {

    public static bool facingRight;

    //takes position of object hitting the egg or whatever and changes their position to simulate a knockback effect, with power KB_Power
    public static float back(BoxCollider2D col, int KB_Power){
        float vector = col.transform.position.x;//current position of enemy

        if (facingRight){
            //if facing right, then get knocked back to the left
            vector = col.transform.position.x + KB_Power;
        }

        else{
            //if facing left, get knocked back to the right
            vector = col.transform.position.x - KB_Power;
        }

        return vector;
    }
}//end class
