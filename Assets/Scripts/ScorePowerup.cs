using UnityEngine;
using System.Collections;

public class ScorePowerup : Powerup {

    //overrides abstract method in parent
    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //destroys current gameObject during collision with player
            DestroyAndMakeFalse();
            player.ScorePowerUp(100);
          
        }
    }

}
