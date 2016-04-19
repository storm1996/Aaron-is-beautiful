using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private Player player;

	public GameObject deathParticle;
	public GameObject respawnParticle; 
	public float respawnDelay; 

	private float gravityStore = 5f; 

	void Start (){ player = FindObjectOfType<Player> ();}//finds player gameobject

	public void RespawnPlayer(){ StartCoroutine ("RespawnPlayerCo");}//respawns player if killed

	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false; 
		player.GetComponent<Renderer> ().enabled = false;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero; 
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true; 
		player.GetComponent<Renderer> ().enabled = true;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}//end class
