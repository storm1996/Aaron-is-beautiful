using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup {


    //calls Start() in parent to define outside scripts
    new void Start()
    {
        base.Start();
    }


    public override void OnTriggerEnter2D(Collider2D col)
    {
		
        if (col.CompareTag("Player"))
        { 
            //in abstract class
            DestroyAndMakeFalse();

            //player.HealthPowerUp(100);
        }
    }

}
