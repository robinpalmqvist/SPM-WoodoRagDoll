using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour {

    public Transform Cube;
    private Quaternion _rotation;
    public Transform RotationalEffector;
	// Use this for initialization
	void Start () {

        Cube.rotation = Quaternion.Euler(0, RotationalEffector.eulerAngles.y, 0);


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
