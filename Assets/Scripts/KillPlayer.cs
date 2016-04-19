using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager; 
	private Player player;

	// Use this for initialization
	void Start ()
	{
		levelManager = FindObjectOfType<LevelManager> ();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			levelManager.RespawnPlayer ();
			player.Damage(1);
		}
	}
}

