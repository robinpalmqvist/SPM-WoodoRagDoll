using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Controller {

    //public CharacterController controller;
    //public Transform _transform;
    public Rigidbody rb;
    
    //private float _force = 20;

    [Range(0f, 1f)] public float InputRequiredToMove = 0.3f;

    public Vector3 Input
    {
        get
        {
<<<<<<< HEAD
            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("LeftStickHorizontal"), 0.0f, UnityEngine.Input.GetAxisRaw("LeftStickVertical"));

            //float y = Camera.main.transform.rotation.eulerAngles.y;
            //input = Quaternion.Euler(0f, y, 0f) * input;
            //return input;
=======
            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), 0.0f, UnityEngine.Input.GetAxisRaw("Vertical"));

            return input;
>>>>>>> c835be20f82925469b064d773a17fb084cae4dc3

            float y = Camera.main.transform.rotation.eulerAngles.y;
            input = Quaternion.Euler(0f, y, 0f) * input;
            return input.normalized;

<<<<<<< HEAD
            //Kan (borde?) normaliseras
=======

>>>>>>> c835be20f82925469b064d773a17fb084cae4dc3
        }
    }



<<<<<<< HEAD
   
=======
    private void Update()
    {
        //rb.AddForce(Input * 20f);


    }
>>>>>>> c835be20f82925469b064d773a17fb084cae4dc3


}
