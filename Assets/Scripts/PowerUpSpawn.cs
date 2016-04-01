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


	// Use this for initialization
	void Start () {

        //takes prefab from resources folder of powerup. isntantiates it later
        healthPowerUp = Resources.Load("Powerup") as GameObject;
        scorePowerUp = Resources.Load("ScorePower") as GameObject;


        //loads all spawn points using tag
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Point");

        for (int i = 0; i < exists.Length; i++)
        {
            makeFalse(i);
        }


	}
	
	void Update () {

        //only spawn when there are no more powerups
        if(checkNoPowers() < 2)
        {
            //calls it two seconds after condition true
            Invoke("spawn", 2);
        }

	}

    

    public void spawn()
    {
        //goes through each transform and flips coin to see if it will be instantiated or not
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int choice = Random.Range(0, 2);

            if(choice > 0)
            {
                if(exists[i].Equals(false))
                {
                    int goChoice = Random.Range(0, 2);

                    if (goChoice > 0)
                    {
                        //instantiates the power up at position i.
                        generateSpawn("Score", i);
                    }
                    else
                    { 
                        generateSpawn("Health", i);
                    }               
                }                                               
            }
        }

        //stops spawn fcn from constantly repeating
        CancelInvoke("spawn");
    }

    private void generateSpawn(string input, int position)
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

        setPosMakeTrue(pow, position);
    }

    public void setPosMakeTrue(Powerup pow, int p)
    {
        pow.setPosition(p);
        makeTrue(p);
    }

    //checks number of power ups on game
    public int checkNoPowers()
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

    public void makeTrue(int x)
    {
        exists[x] = true;
    }

    public void makeFalse(int x)
    {
        exists[x] = false;
    }
}
