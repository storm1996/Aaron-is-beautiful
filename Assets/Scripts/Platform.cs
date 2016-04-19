using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    private BoxCollider2D platformCollider;
    private Rigidbody2D platformProperties;

    // Use this for initialisation
    void Start(){ 
        

        platformCollider = gameObject.AddComponent<BoxCollider2D>();
        platformCollider.size = new Vector2(1, 1);
		//platformCollider.isTrigger = true; 

        platformProperties = gameObject.AddComponent<Rigidbody2D>();
        platformProperties.drag = 1f;
        platformProperties.isKinematic = true;

    }

}
