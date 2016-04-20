using UnityEngine;
using System.Collections;

//gives borders colliders
public class Borders : MonoBehaviour
{
    private BoxCollider2D borderCollider;
    private Rigidbody2D borderProperties;

    // gives borders a collider and rigidbody
    void Start(){
        borderCollider = gameObject.AddComponent<BoxCollider2D>();
        borderCollider.size = new Vector2(1, 1);
        borderProperties = gameObject.AddComponent<Rigidbody2D>();
        borderProperties.isKinematic = true;
    }

}//end class
