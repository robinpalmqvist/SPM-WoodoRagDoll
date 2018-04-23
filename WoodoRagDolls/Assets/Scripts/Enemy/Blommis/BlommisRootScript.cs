using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlommisRootScript : MonoBehaviour {

    public float health;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("Player"))
        {
            gameObject.SetActive(false);
        }
    }
    // When sword is active, and colliding with the root, if the force is enough?? the root is hurt.
    // baserat på magnituden, om den är högre än ett maxvärde, ex 2, om den är mindre, den floaten.
    // skadan ska aldrig kunna få livet att gå under 0
    //
}
