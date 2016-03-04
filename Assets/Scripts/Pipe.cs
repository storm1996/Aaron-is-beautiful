using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //colour for spawn pipes, to better see them
        GetComponent<Renderer>().material.color = new Color(0.5f, 255, 255, 255);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
