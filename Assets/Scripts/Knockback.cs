

using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour {

    public static float back(BoxCollider2D col, int KB_Power)
    {
        //takes position of object hitting the egg or whatever and changes their position to simulate a knockback effect, with power KB_Power
        float vector = col.transform.position.x + KB_Power;
        return vector;
    }

}
