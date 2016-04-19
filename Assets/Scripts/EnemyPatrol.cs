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

    // spawns enemies and starts level at 0
	void Start(){
        level = 0;
        enemy = Resources.Load("Enemy") as GameObject;
        spawnPoint = GameObject.FindGameObjectWithTag("Enemy Spawn");
    }

    // if no enemies left, then increase level, restart spawning enemies
    void Update(){ 
        if (Enemies() < 1){
            // makes sure run once
            if (isExecuting){ 
                LevelUp();
                Invoke("SpawnHere", 0);
            }
        }
        
        // sets isExecuting to true if no enemies left
        CheckExecute();
    }

    public void LevelUp(){ level++;}// level increase

    // spawns enemies, with enemy number depending on level 
    public void SpawnHere(){
        int noEnemies = 3 + level;

        for(int i = 0; i < noEnemies; i++){
            int choice = Random.Range(0, 2);

            // chooses direction enemy goes depending on random number
            if(choice > 0){ StartCoroutine(WaitAndSpawn(i, "Left"));}
            else{ StartCoroutine(WaitAndSpawn(i, "Right"));}
        }

        //cancels invoke from repeating and check in update only executed once
        isExecuting = false;
        CancelInvoke("SpawnHere");
    }

    //spawns enemy after set time, chooses their direction
    IEnumerator WaitAndSpawn(float time, string direction){
        yield return new WaitForSeconds(time);

        if (direction.Equals("Left")){
            GameObject newObject = (GameObject)Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
            newObject.GetComponent<Enemy>().SetDirection(true);// switches enemy direction
        }

        else if (direction.Equals("Right")){ GameObject newObject = (GameObject)Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);}
    }

    //if enemy amount on screen is 0 set isExecuting to true
    public void CheckExecute(){ if(enemies.Length == 0){ isExecuting = true;}}
    
    //returns amount of enemies on screen
    public int Enemies(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length;
    }

}//end class