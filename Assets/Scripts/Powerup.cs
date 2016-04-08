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
        PlayerMake();
        power = GameObject.FindGameObjectWithTag("Ground").GetComponent<PowerUpSpawn>();
    }

    public virtual void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 250f);
    }


    private void PlayerMake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public abstract void OnTriggerEnter2D(Collider2D col);

    //hold position relative to powerUpSpawns
    public void SetPosition(int x)
    {
        this.position = x;
    }

    public void DestroyAndMakeFalse()
    {
        Destroy(gameObject);
        power.SetStateAtPos(position, false);
    }
 
}
