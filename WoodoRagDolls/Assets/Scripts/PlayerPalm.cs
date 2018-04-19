using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPalm : MonoBehaviour {

    public float Force = 4000;
    //private Rigidbody rb;
    private bool attached = false;

    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!attached)
        {
            SpringJoint sp = gameObject.AddComponent<SpringJoint>();
            sp.connectedBody = col.rigidbody;
            sp.spring = 12000;
            sp.breakForce = Force;
            attached = true;
        }
    }

    private void OnJointBreak()
    {
        attached = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
