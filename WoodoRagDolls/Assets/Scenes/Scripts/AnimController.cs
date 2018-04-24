using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {

    public Rigidbody[] rigidbodys;
    public Animator anim;
	// Use this for initialization
	void Start () {
        rigidbodys = gameObject.GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.enabled = false;
        } else if (Input.GetKeyDown(KeyCode.Y))
        {
            anim.enabled = true;
        }
	}
}
