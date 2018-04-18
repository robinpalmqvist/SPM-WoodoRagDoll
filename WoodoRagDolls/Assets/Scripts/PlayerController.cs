using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Controller {

    public CharacterController controller;
    public Rigidbody rb;

    [Range(0f, 1f)] public float InputRequiredToMove = 0.3f;

    public Vector3 Input
    {
        get
        {
            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), 0.0f, UnityEngine.Input.GetAxisRaw("Vertical"));
            float y = Camera.main.transform.rotation.eulerAngles.y;
            input = Quaternion.Euler(0f, y, 0f) * input;
            return input;
            //Kan (borde?) normaliseras
        }
    }


	private void Update()
	{
        //Vector3 move = new Vector3(Input.GetAxis("Vertical"), -5f, Input.GetAxis("Horizontal"));

	}


}
