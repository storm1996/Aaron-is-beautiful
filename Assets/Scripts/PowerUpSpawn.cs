using UnityEngine;
using System.Collections;

public class PowerUpSpawn : MonoBehaviour {

    //spawn points in array specified in inspector with spawn child objects in testing ground object children
    //need to code it in
    public GameObject[] spawnPoints;

    //finds positions where power ups are currently
    private bool[] exists = new bool[5];

    //specified with powerup prefab
    public GameObject healthPowerUp;
    public GameObject scorePowerUp;

    private bool isCoroutineExecuting = false;


	// Use this for initialization
	void Start () {

        //takes prefab from resources folder of powerup. isntantiates it later
        healthPowerUp = Resources.Load("HealthPower") as GameObject;
        scorePowerUp = Resources.Load("ScorePower") as GameObject;


        //loads all spawn points using tag
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Point");

        //initialises all positions to false
        for (int i = 0; i < exists.Length; i++)
        {
            SetStateAtPos(i, false);
        }
    }
	
	void Update () { 

        //spawns two seconds after condition true
        if (CheckNoPowers() < 2)
        {      
            Invoke("Spawn", 2);
        }
	}

    public void Spawn()
    { 
        //goes through each transform and flips coin to see if it will be instantiated or not
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int choice = Random.Range(0, 2);
            float spawnTimer = Random.Range(0f, 5f);


            if(choice > 0)
            {
                if(exists[i].Equals(false))
                {
                    int goChoice = Random.Range(0, 2);

                    StartCoroutine(WaitAndSpawn(spawnTimer, goChoice, i));              
                }                                               
            }
        }

        //stops spawn function from constantly repeating
        CancelInvoke("Spawn");
    }

    IEnumerator WaitAndSpawn(float time, int choice, int position)
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }

        isCoroutineExecuting = true;
        
        //waits for time to execute after this 
        yield return new WaitForSeconds(time);

        if (choice > 0)
        {
            //instantiates the power up at position i.
            GenerateSpawn("Score", position);
            Debug.Log("SPAWNED. POS : " + position);
        }
        else
        { 
            GenerateSpawn("Health", position);
            Debug.Log("SPAWNED. POS : " + position);
        }

        isCoroutineExecuting = false;
    }

  
    private void GenerateSpawn(string input, int position)
    {   
        Powerup pow = null;

        if (input.Equals("Score"))
        {
            GameObject newObject = (GameObject)Instantiate(scorePowerUp, spawnPoints[position].transform.position, Quaternion.identity);
            //polymorphism
            pow = newObject.GetComponent<ScorePowerup>();
        }
        else if (input.Equals("Health"))
        {
            GameObject newObject = (GameObject)Instantiate(healthPowerUp, spawnPoints[position].transform.position, Quaternion.identity);
            pow = newObject.GetComponent<HealthPowerup>();          
        }

        //makes position true at position
        SetPosMakeTrue(pow, position);
    }
    

    public void SetPosMakeTrue(Powerup pow, int p)
    { 
        pow.SetPosition(p);
        SetStateAtPos(p, true);
    }

    //checks number of power ups on game
    public int CheckNoPowers()
    {
        int count = 0;

        for(int i = 0; i < exists.Length; i++)
        {
            if (exists[i].Equals(true))
            {
                count++;
            }
        }
        
        return count;
    }

    //sets flag at position
    public void SetStateAtPos(int x, bool value)
    {
        exists[x] = value;
    }
}
