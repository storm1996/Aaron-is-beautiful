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

    //virtual used so it can be called from child
    //auto called by child classes 
    public virtual void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        powerScript = GameObject.FindGameObjectWithTag("Powerup Spawn System").GetComponent<PowerUpSpawn>();
        timer = Random.Range(10f, 20f);
        Debug.Log("Pos: "+ position + "     Time: " + timer);
 
        setTime = Time.time + timer;
    }

    public virtual void Update()
    {
        //constantly spins powerup in both inherited classes
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * spinSpeed);

        if(Time.time >= setTime)
        {
            DestroyAndMakeFalse();
        }
    }

    //abstract method for collisions in inherited classes
    public abstract void OnTriggerEnter2D(Collider2D col);

    //hold position relative to powerUpSpawns
    public void SetPosition(int x)
    {
        this.position = x;
    }

    //destroys self and lets position to be used again
    public void DestroyAndMakeFalse()
    {
        Debug.Log("DESTROYING. Pos: " + position);
        Destroy(gameObject);
        powerScript.SetStateAtPos(position, false);

    }
 
}
