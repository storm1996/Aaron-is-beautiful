/*
Shows Level, Egg health, Playe Score
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour {
    public Text showScore;
    public Text showEggHP;
    public Text showLevel;
    public Player player;
    public Egg egg;
    public Enemy enLevel;

    void Start(){
        Screen.SetResolution(1200, 675, true, 60);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        egg = GameObject.FindGameObjectWithTag("Egg").GetComponent<Egg>();
        showScore = (Text)GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        showEggHP = (Text)GameObject.FindGameObjectWithTag("EggHP").GetComponent<Text>();
        showLevel = (Text)GameObject.FindGameObjectWithTag("Level").GetComponent<Text>();
    }

    void Update(){
        setScoreText();
        setEggText();
        setLevelText();
    }

    private void setLevelText(){
        showLevel.text = "Level: " + EnemyPatrol.lvlCheck().ToString();
    }

    private void setEggText(){
        showEggHP.text = "Egg HP: " + egg.eggHealth.ToString();
    }

    private void setScoreText(){
        showScore.text = "Score: " + player.score.ToString();
    }
}//end class
