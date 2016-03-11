using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    private Player player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GetComponent<Renderer>().material.color = new Color(155, 0, 155, 0);
    }

    // Update is called once per frame
    void Update () {
	
	}


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(player.teleport());
        }
    }
}
