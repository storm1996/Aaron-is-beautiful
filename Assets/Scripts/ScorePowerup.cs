using UnityEngine;
using System.Collections;

public class ScorePowerup : MonoBehaviour {

    private Player player;
    private PowerUpSpawn power;
    private int position;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        power = GameObject.FindGameObjectWithTag("Ground").GetComponent<PowerUpSpawn>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //destroys current gameObject during collision with player
            Destroy(gameObject);
            player.scorePowerUp(100);

            //sets array element in PowerUpSpawn to be false
            power.makeFalse(position);
        }
    }

    public void setPosition(int x)
    {
        this.position = x;
    }
}
