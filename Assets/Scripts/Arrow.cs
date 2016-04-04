using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Invoke("die", 2);
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("die", 2);
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
