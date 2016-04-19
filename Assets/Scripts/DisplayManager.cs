/*
CONTROL HEALTH AND SCORE DELAY
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour {

    public Text showHealth;
    public Text showScore;
    public Text showEggHP;
    public Player player;
    public Egg egg;

    void Start(){
        Screen.SetResolution(1200, 675, true, 60);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<Egg>();
        showHealth = (Text)GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        showScore = (Text)GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        showEggHP = (Text)GameObject.FindGameObjectWithTag("EggHP").GetComponent<Text>();
    }

    void Update(){ 
        setHealthText();
        setScoreText();
        setEggText();
    }

    private void setEggText(){
        showEggHP.text = "Egg HP: " + egg.eggHealth.ToString();
    }

    //sets the health and score
    private void setHealthText(){
        showHealth.text = "Health: " + player.health.ToString();
    }

    private void setScoreText(){
        showScore.text = "Score: " + player.score.ToString();
    }
}//end class
