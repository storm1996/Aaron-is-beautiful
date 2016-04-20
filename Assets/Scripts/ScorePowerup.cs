using UnityEngine;
using System.Collections;

public class ScorePowerup : Powerup {

    //overrides abstract method in parent
    public override void OnTriggerEnter2D(Collider2D col){

        //destroys current gameObject during collision with playera
        if (col.CompareTag("Player")){            
            PowerUpSpawn.play();
            DestroyAndMakeFalse();
            player.PowerUp("Score", 10);
        }
    }

}//end class
