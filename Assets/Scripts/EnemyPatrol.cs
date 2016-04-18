using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    private GameObject enemy;
    public GameObject[] enemies;
    public GameObject leftSpawn;
    public GameObject rightSpawn;
    private bool isCoroutineExecuting = false;
    private float time;
    private int enemyQuant;
    private bool noneLeft = false;
    private bool isExecuting = true;

	void Start()
	{
        enemy = Resources.Load("Enemy") as GameObject;
        rightSpawn = GameObject.FindGameObjectWithTag("Right Enemy Spawn");
        leftSpawn = GameObject.FindGameObjectWithTag("Left Enemy Spawn");

    }

    void Update()
    {
        if (Enemies() < 1)
        {
            
            if (isExecuting == true)
            {
                Debug.Log("Execute");
                Invoke("SpawnHere", 0);
            }
            
            //noneLeft = false;
        }

        CheckExecute();
    }

    public void SpawnHere()
    {
        int noEnemies = 5;

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

        isExecuting = false;
        CancelInvoke("SpawnHere");
    }

    IEnumerator WaitAndSpawn(float time, string direction)
    {
   /*     //GameObject newObject;
        if (isCoroutineExecuting)
        {
            yield break;
        }
*/
       // isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        if (direction.Equals("Left"))
        {
            GameObject newObject = (GameObject)Instantiate(enemy, leftSpawn.transform.position, Quaternion.identity);
            newObject.GetComponent<Enemy>().SetDirection(true);
        }
        else if (direction.Equals("Right"))
        {
            GameObject newObject = (GameObject)Instantiate(enemy, rightSpawn.transform.position, Quaternion.identity);

        }

        //isCoroutineExecuting = false;

    }


    public bool NoEnemiesLeft()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length == 0)
        {
            noneLeft = true;
        }

        return noneLeft;
        
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