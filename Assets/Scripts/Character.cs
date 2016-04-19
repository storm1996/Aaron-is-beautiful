using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

    public int health;
    public float speed;
    //public bool facingRight;
/*
	// Use this for initialization
	public virtual void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */
    public abstract void MoveControl();

    public void Damage(int value)
    {
        health -= value;
    }

}
