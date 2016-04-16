using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    private GameObject enemy;
    public GameObject[] enemies;
    public GameObject leftSpawn;
    public GameObject rightSpawn;
    private bool isCoroutineExecuting;
    private float time;

	void Start()
	{
        enemy = Resources.Load("Enemy") as GameObject;
        rightSpawn = GameObject.FindGameObjectWithTag("Right Enemy Spawn");
        leftSpawn = GameObject.FindGameObjectWithTag("Left Enemy Spawn");

        for(int i = 0; i < 5; i++)
        {
            time = i;
            StartCoroutine(WaitAndSpawn(time));
        }
    }

	void Update()
	{
		
	}

    IEnumerator WaitAndSpawn(float time)
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }

        yield return new WaitForSeconds(time);

        GameObject newObject = (GameObject)Instantiate(enemy, leftSpawn.transform.position, Quaternion.identity);

        isCoroutineExecuting = false;

    }
}