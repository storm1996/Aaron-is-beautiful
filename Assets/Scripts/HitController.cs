using UnityEngine;
using System.Collections;

public class HitController : MonoBehaviour {

    BoxCollider2D boxCollider;
    Player player;
	// Use this for initialization
	void Start () {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        player = gameObject.GetComponentInParent<Player>();
        boxCollider.isTrigger = true;
	}
	

    public void OnTriggerStay2D(Collider2D col)
    {
        //will only let hitting where it faces
        if (player.facingRight && gameObject.tag.Equals("Hit Right") && col.CompareTag("Test"))
        {
            HitTest(col);
        }
        else if (!player.facingRight && gameObject.tag.Equals("Hit Left") && col.CompareTag("Test"))
        {
            HitTest(col);
        }
    }

    void HitTest(Collider2D col)
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("HIT");
        }

    }
}
