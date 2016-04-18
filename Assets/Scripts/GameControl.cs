using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

    public GameObject[] enemies;
    public int level;
    private EnemyPatrol spawningSytem;
    private bool executeOnce = false;
    //private bool is

	// Use this for initialization
	void Start () {
        level = 1;
        spawningSytem = GameObject.FindGameObjectWithTag("Spawn System").GetComponent<EnemyPatrol>();
	}
	
	// Update is called once per frame
	void Update () {

        
        if (GetNoEnemies() <= 0)
        {
            //add level up here
            
            //Invoke("SpawnEnemies", 3);
        }
	}

    public void SpawnEnemies()
    {
        //spawningSytem.Spawn(level);
       // level++;
        
       // CancelInvoke("SpawnEnemies");
    }

    public int GetNoEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        return enemies.Length;
    }






}
