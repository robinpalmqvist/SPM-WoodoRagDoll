using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MiniBossController : Controller{

    public Transform[] Targets;
    public LayerMask TargetMask;
    public CharacterController Character;
   


   

	// Use this for initialization
	void Start () {
      
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
