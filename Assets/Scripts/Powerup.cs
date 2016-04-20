/*
Abstract class for HealthPowerup and ScorePowerup
*/

using UnityEngine;
using System.Collections;

public abstract class Powerup : MonoBehaviour {

    public Player player;
    public PowerUpSpawn powerScript;
    public int position;

    private float timer;
    private float setTime;
    private float spinSpeed = 250f;
    private float minTime; 
    private float maxTime;

    //virtual used so it can be called from child
    //auto called by child classes 
    public virtual void Start(){ 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        powerScript = GameObject.FindGameObjectWithTag("Powerup Spawn System").GetComponent<PowerUpSpawn>();

        //sets value between min and max seconds that powerup can exist for
        minTime = 8f;
        maxTime = 12f;
        timer = Random.Range(minTime, maxTime);
        setTime = Time.time + timer; 
        
    }

    public virtual void Update(){

        //constantly spins powerup in both inherited classes
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * spinSpeed);

        //destroys powerup after a certain time
        if(Time.time >= setTime){ DestroyAndMakeFalse();}
    }

    //abstract method for collisions in inherited classes
    public abstract void OnTriggerEnter2D(Collider2D col);

    //hold position relative to powerUpSpawns
    public void SetPosition(int x){ this.position = x;}

    //destroys self and lets position to be used again
    public void DestroyAndMakeFalse(){
        Destroy(gameObject);
        powerScript.SetStateAtPos(position, false); //frees up spawn position to be used again
    }
 
}//end class
