/*
CHILD CLASS OF POWERUP
HOLDS HEALTH
*/
using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup { 

    // calls Start() in parent to define outside scripts
    new void Start(){ base.Start();}

    //if palyer is touching healthpowerup, then destroy it, and increase health score
    public override void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            DestroyAndMakeFalse();
            player.PowerUp("Health", 10);
        }
    }
}//end class
