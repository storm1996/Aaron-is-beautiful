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

    private bool isExecuting = false;

	void Start()
	{
        enemyQuant = 5;
        enemy = Resources.Load("Enemy") as GameObject;
        rightSpawn = GameObject.FindGameObjectWithTag("Right Enemy Spawn");
        leftSpawn = GameObject.FindGameObjectWithTag("Left Enemy Spawn");

        
    }

    public void Spawn(int level)
    {
        enemyQuant = 5 * (level - 1);

        for (int i = 0; i < enemyQuant; i++)
        {
            time = i;
            int choice = Random.Range(0, 2);

            if (choice > 0)
            {
                StartCoroutine(WaitAndSpawn(time, "Left"));
            }
            else
            {
                StartCoroutine(WaitAndSpawn(time, "Right"));
            }
        }
    }

    IEnumerator WaitAndSpawn(float time, string direction)
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        if (direction.Equals("Left"))
        {
            GameObject newObject = (GameObject)Instantiate(enemy, leftSpawn.transform.position, Quaternion.identity);
            newObject.GetComponent<Enemy>().SetDirection(true);
        }
        else if (direction.Equals("Right"))
        {
            GameObject newObject = (GameObject)Instantiate(enemy, rightSpawn.transform.position, Quaternion.identity);
            newObject.GetComponent<Enemy>().SetDirection(false);
        }

  
        isCoroutineExecuting = false;

    }

    public int NoOfEnemies()
    {
        return enemies.Length;
    }

    
}