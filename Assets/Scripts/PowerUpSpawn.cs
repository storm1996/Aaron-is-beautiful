using UnityEngine;
using System.Collections;

public class PowerUpSpawn : MonoBehaviour {

    /*
    Shit to do:

        need to add power up prefab in the code.
    */

    //spawn points in array specified in inspector with spawn child objects in testing ground object children
    public Transform[] powerUpSpawns;

    //specified with powerup prefab
    public GameObject powerUp;

	// Use this for initialization
	void Start () {
        
        spawn();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void spawn()
    {
        //goes through each transform and flips coin to see if it will be instantiated or not
        for(int i = 0; i < powerUpSpawns.Length; i++)
        {
            int choice = Random.Range(0, 2);

            if(choice > 0)
            {
                //instantiates the power up at whatever position.
                Instantiate(powerUp, powerUpSpawns[i].position, Quaternion.identity);
                
            }

        }
    }
}
