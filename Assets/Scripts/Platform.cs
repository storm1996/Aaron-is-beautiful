using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BoxCollider2D platformCollider = gameObject.AddComponent<BoxCollider2D>();
        platformCollider.size = new Vector2(1, 1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
