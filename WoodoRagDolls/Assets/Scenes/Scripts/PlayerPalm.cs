using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPalm : MonoBehaviour {

    public float Force = 4000;
    public Rigidbody leftHand, rightHand;
    
    private bool attached = false;
    private float MoveSpeed = 100f;

    [Range(0f, 1f)] public float InputRequiredToMove = 0.3f;

    public Vector3 _Input
    {
        get
        {
            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("RightStickHorizontal"), UnityEngine.Input.GetAxisRaw("RightStickVertical"), 0.0f );

            //float y = Camera.main.transform.rotation.eulerAngles.y;
            //input = Quaternion.Euler(0f, y, 0f) * input;
            return input.normalized;

        }
    }


    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("In method but not attached");
        if (!attached && Input.GetAxis("XboxRightTrigger") > 0)
        {
            Debug.Log("Should be attached");
            SpringJoint sp1 = leftHand.gameObject.AddComponent<SpringJoint>();
            sp1.connectedBody = col.rigidbody;
            sp1.spring = 12000;
            sp1.breakForce = Force;
            attached = true;

            SpringJoint sp2 = rightHand.gameObject.AddComponent<SpringJoint>();
            sp2.connectedBody = col.rigidbody;
            sp2.spring = 12000;
            sp2.breakForce = Force;
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

        //if (Input.GetAxis("XboxRightTrigger") > 0)
        //{
        //    Debug.Log("serhserh");
        //}
        if (_Input.magnitude > Mathf.Epsilon)
        {
            
            leftHand.AddForce(_Input * MoveSpeed, ForceMode.Acceleration);
            rightHand.AddForce(_Input * MoveSpeed, ForceMode.Acceleration);
        }
    }
}
