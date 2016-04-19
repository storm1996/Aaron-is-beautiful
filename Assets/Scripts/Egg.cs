using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour
{
    public BoxCollider2D eggCollider;
    public Rigidbody2D eggProperties;

    public int eggHealth;// 5 hits to kill egg
    public bool hit;

    public BoxCollider2D eggHitter;
    public Rigidbody2D eggHitterRB;
    public float eggHitterVC2;

    public AudioClip[] sounds;//holds sound files

    void Start(){

        sounds = new AudioClip[]{
            Resources.Load("Sound_Cracking") as AudioClip,
            Resources.Load("Sound_Hit") as AudioClip
        };

        hit = false;
        eggHealth = 5;
        eggCollider = gameObject.AddComponent<BoxCollider2D>();
        eggCollider.size = new Vector2(1, 1);

        eggProperties = gameObject.AddComponent<Rigidbody2D>();
        eggProperties.drag = 1f;
        eggProperties.isKinematic = true;

        Physics2D.IgnoreLayerCollision(8,9,true); //ignores player and egg layer collisions - layer 8 and 9

    }//end start

    public void Update(){

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
            if (eggCollider.IsTouching(obj.GetComponent<BoxCollider2D>()) && !hit){
                Enemy enemy = obj.GetComponent<Enemy>();
                //StartCoroutine(enemy.KnockBack(0.02f, 500f, obj.transform.position));
                StartCoroutine("EggHittable", enemy);
            }
        }
    }//end update

    //let's enemies deal damage to egg
    public void EggHittable(Enemy en){
        hit = true;
        StartCoroutine(Wait());
        Invoke("falser", 2);
        en.KnockBack(0.1f, 500f, en.transform.position);
        //hit = true;
        //eggHitterVC2 = Knockback.back(eggHitter, -2);
        //eggHitterRB.transform.position = new Vector2(eggHitterVC2, eggHitterRB.transform.position.y);
    }

    IEnumerator Wait(){
        AudioSource.PlayClipAtPoint(sounds[1], Vector2.zero);
        yield return new WaitForSeconds(0.3f);
        AudioSource.PlayClipAtPoint(sounds[0], Vector2.zero);
    }

    public void falser(){
        eggHealth--;
        hit = false;
    }
}//end class
