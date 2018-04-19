using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Controller {

    public CharacterController controller;
    public Transform _transform;
   // public Rigidbody rb;
    //private float _force = 20;

    [Range(0f, 1f)] public float InputRequiredToMove = 0.3f;

    public Vector3 Input
    {
        get
        {
            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), 0.0f, UnityEngine.Input.GetAxisRaw("Vertical"));
<<<<<<< HEAD
            //float y = Camera.main.transform.rotation.eulerAngles.y;
            //input = Quaternion.Euler(0f, y, 0f) * input;
            return input;
=======
            float y = Camera.main.transform.rotation.eulerAngles.y;
            input = Quaternion.Euler(0f, y, 0f) * input;
            return input.normalized;
>>>>>>> ddebe0bf26d1e2c92a14c8dce5754af97b5ab9c7
            //Kan (borde?) normaliseras
        }
    }


<<<<<<< HEAD
	private void Update()
	{
        rb.AddForce(Input * 20f);
=======
    
>>>>>>> ddebe0bf26d1e2c92a14c8dce5754af97b5ab9c7

	


}
