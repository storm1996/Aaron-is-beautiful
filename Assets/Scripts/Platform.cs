using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    private BoxCollider2D platformCollider;
    private Rigidbody2D platformProperties;

    // gives platforms a collider and rigidbody
    void Start(){
        platformCollider = gameObject.AddComponent<BoxCollider2D>();
        platformCollider.size = new Vector2(50, 3);
		platformCollider.offset = new Vector2(0, -3);
        platformProperties = gameObject.AddComponent<Rigidbody2D>();
        platformProperties.drag = 1f;
        platformProperties.isKinematic = true;
    }

}//end class
