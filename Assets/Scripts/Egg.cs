using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour
{
    public BoxCollider2D eggCollider;
    public Rigidbody2D eggProperties;
    public AudioClip[] sounds;//holds sound files
    public int eggHealth;
    public bool hit;
    private Player player;

    void Start(){
        sounds = new AudioClip[]{
            Resources.Load("Sound_Cracking") as AudioClip,
            Resources.Load("Sound_Hit") as AudioClip};

        hit = false;
        eggHealth = 5;// 5 hits to kill egg
        eggCollider = gameObject.AddComponent<BoxCollider2D>();
        eggProperties = gameObject.AddComponent<Rigidbody2D>();
        eggCollider.size = new Vector2(1, 1);
        eggProperties.drag = 1f;
        eggProperties.isKinematic = true;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Physics2D.IgnoreLayerCollision(8,9,true); //ignores player and egg layer collisions - layer 8 and 9
    }//end start

    public void Update(){

        //loop that cycles through enemies on screen to see if egg was hit
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
            if (eggCollider.IsTouching(obj.GetComponent<BoxCollider2D>()) && !hit){
                Enemy enemy = obj.GetComponent<Enemy>();//the enemy that hit the egg
                StartCoroutine("EggHittable", enemy);//starts sequence of egg damage and sounds
            }
        }

		if (eggHealth == 0) {
			Application.LoadLevel (3);
		}

        //if egg health less than equal to 9, then increase health by 1, until egg health is 10 max
        if (eggHealth <= 9){
            if(player.score >= 100){
                eggHealth += 1;
                player.score -= 100;
            }
        }
    }//end update

    //stops enemies from dealing damage to egg for 2 seconds, deals damage, plays cracking sound
    public void EggHittable(Enemy en){
        hit = true;
        eggHealth--;
        StartCoroutine(Wait());
        en.KnockBack(0.1f, 500f, en.transform.position);
        Invoke("falser", 2);//two second delay for damage dealt to egg
    }

    //thread that plays hit sound + cracking sound
    IEnumerator Wait(){
        AudioSource.PlayClipAtPoint(sounds[1], Vector2.zero);
        yield return new WaitForSeconds(0.3f);
        AudioSource.PlayClipAtPoint(sounds[0], Vector2.zero);
    }

    //lets enemies deal damage to egg
    public void falser(){ hit = false;}

}//end class
