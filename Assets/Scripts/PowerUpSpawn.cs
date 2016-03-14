using UnityEngine;
using System.Collections;

public class PowerUpSpawn : MonoBehaviour {

    //spawn points in array specified in inspector with spawn child objects in testing ground object children
    //need to code it in
    public GameObject[] spawnPoints;

    //finds positions where power ups are currently
    private bool[] exists = new bool[5];

    //specified with powerup prefab
    public GameObject powerUp;
 
	// Use this for initialization
	void Start () {

        //takes prefab from resources folder of powerup. isntantiates it later
        powerUp = Resources.Load("Powerup") as GameObject;

        //spawnPoints = new GameObject[];

        //loads all spawn points using tag
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Point");

        for (int i = 0; i < exists.Length; i++)
        {
            makeFalse(i);
        }

	}
	
	void Update () {

        //only spawn when there are no more powerups
        if(checkNoPowers() == 0)
        {
            spawn();
        }

	}

    private void spawn()
    {
        //goes through each transform and flips coin to see if it will be instantiated or not
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int choice = Random.Range(0, 2);

            if(choice > 0)
            {
                //instantiates the power up at position i.
                GameObject newObject = (GameObject)Instantiate(powerUp, spawnPoints[i].transform.position, Quaternion.identity);
                Powerup pow = newObject.GetComponent<Powerup>();

                pow.setPosition(i);
                makeTrue(i);            
                            
            }
        }
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
