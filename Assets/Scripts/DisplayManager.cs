/*
CONTROL HEALTH AND SCORE DELAY
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour {

    public Text showHealth;
    public Text showScore;
    public Player player;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        showHealth = (Text)GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        showScore = (Text)GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
	
	void Update () {
        setHealthText();
        setScoreText();
    }

    //sets the health and score
    private void setHealthText()
    {
        
        showHealth.text = "Health: " + player.health.ToString();
    }

    private void setScoreText()
    {
        showScore.text = "Score: " + player.score.ToString();
    }
}
