using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup {

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        { 
            //in abstract class
            DestroyAndMakeFalse();

            player.HealthPowerUp(100);
        }
    }

}
