/*
ABSTRACT CLASS FOR PLAYER AND ENEMY SCRIPTS
*/

using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

    public int health;
    public float speed;

    public abstract void MoveControl();
    public abstract void Flip();

    public void Damage(int value)
    {
        health -= value;
    }

}
