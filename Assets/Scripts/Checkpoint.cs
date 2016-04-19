using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public LevelManager levelManager;

    //find object with type levelmanager
	void Start (){ levelManager = FindObjectOfType<LevelManager> ();}

    //sets checkpoint to player position at collision
	void OnTriggerEnter2D(Collider2D other){ if (other.name == "Player") { levelManager.currentCheckpoint = gameObject;}}

}//end class
