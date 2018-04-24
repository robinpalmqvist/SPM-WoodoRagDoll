using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpNegative : MonoBehaviour {
    public Material Mat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Mat.SetFloat("_LerpValue",  Mathf.Sin(Time.time));
		
	}
}
