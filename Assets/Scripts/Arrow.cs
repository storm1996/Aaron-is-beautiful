using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	void Update () {
        //destroys after two seconds
        Invoke("Die", 2);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
