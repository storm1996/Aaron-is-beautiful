/*
Abstract class for HealthPowerup and ScorePowerup
*/

using UnityEngine;
using System.Collections;

public abstract class Powerup : MonoBehaviour {

    public Player player;
    public PowerUpSpawn power;
    public int position;

    //virtual used so it can be called from child
    public virtual void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        power = GameObject.FindGameObjectWithTag("Ground").GetComponent<PowerUpSpawn>();
    }

    public abstract void OnTriggerEnter2D(Collider2D col);

    //hold position relative to powerUpSpawns
    public void setPosition(int x)
    {
        this.position = x;
    }
 
}
