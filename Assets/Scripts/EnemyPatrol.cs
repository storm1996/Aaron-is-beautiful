/*
CONTROLS ENEMY SPAWNING AND ENEMY COUNT CHECKING
*/

using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    private GameObject enemy;
    public GameObject[] enemies;
    public GameObject spawnPoint;
    private bool isCoroutineExecuting = false;
    private int level;
    private float time;
    private int enemyQuant;
    private bool isExecuting = true;

	void Start()
	{
        level = 0;
        enemy = Resources.Load("Enemy") as GameObject;
        spawnPoint = GameObject.FindGameObjectWithTag("Enemy Spawn");

    }

    void Update()
    { 
        if (Enemies() < 1)
        {
            //makes sure run once
            if (isExecuting)
            { 
                LevelUp();
                Debug.Log("Execute");
                Invoke("SpawnHere", 0);
            }
        }
        
        //sets isExecuting to true if no enemies left
        CheckExecute();
    }

    public void LevelUp()
    {
        level++;
    }
    public void SpawnHere()
    {
        int noEnemies = 3 + level;

        for(int i = 0; i < noEnemies; i++)
        {
            int choice = Random.Range(0, 2);

            if(choice > 0)
            {
                StartCoroutine(WaitAndSpawn(i, "Left"));
            }
            else
            {
                StartCoroutine(WaitAndSpawn(i, "Right"));
            }
        }

        //cancels invoke from repeating and check in update only executed once
        isExecuting = false;
        CancelInvoke("SpawnHere");
    }

    //spawns enemy after set time
    IEnumerator WaitAndSpawn(float time, string direction)
    {
        yield return new WaitForSeconds(time);

        if (direction.Equals("Left"))
        {
            GameObject newObject = (GameObject)Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
            //switches enemy direction
            newObject.GetComponent<Enemy>().SetDirection(true);
        }
        else if (direction.Equals("Right"))
        {
            GameObject newObject = (GameObject)Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    public void CheckExecute()
    {
        if (enemies.Length == 0)
        {
            isExecuting = true;
        }
    }

    public int Enemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length;
    }
}