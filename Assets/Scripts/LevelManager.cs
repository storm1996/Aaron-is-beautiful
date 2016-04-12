using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private Player player;

	public GameObject deathParticle;
	public GameObject respawnParticle; 

	public int pointPenaltyOnDeath;
	public float respawnDelay; 

	private float gravityStore = 5f; 

	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<Player> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false; 
		player.GetComponent<Renderer> ().enabled = false;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero; 
		player.scorePowerUp (-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true; 
		player.GetComponent<Renderer> ().enabled = true;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
