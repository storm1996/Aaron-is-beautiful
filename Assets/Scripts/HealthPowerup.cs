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
            //destroys current gameObject during collision with player
            Destroy(gameObject);
            player.healthPowerUp(100);

            //sets array element in PowerUpSpawn to be false
            power.makeFalse(position);
        }
    }

}
