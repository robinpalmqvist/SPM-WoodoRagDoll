using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPalm : MonoBehaviour {

    public float Force = 4000;
    public Rigidbody AttachedHand;
    //, rightHand;

    public SpringJoint HandJoint;
    //, spRight;

    private bool Attached = false;
        //, rightAttached = false;
    
    private float MoveSpeed = 100f;

    [Range(0f, 1f)] public float InputRequiredToMove = 0.3f;

    public Vector3 _Input
    {
        get
        {
            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("RightStickHorizontal"), UnityEngine.Input.GetAxisRaw("RightStickVertical") ,0.0f );

            //float y = Camera.main.transform.rotation.eulerAngles.y;
            //input = Quaternion.Euler(0f, y, 0f) * input;
            return input.normalized;

        }
    }


    private void OnCollisionEnter(Collision col)
    {
        //Debug.Log("In method but not attached");
        if (HandJoint == null && !Attached && Input.GetAxis("XboxRightTrigger") > 0)
        {
            Debug.Log(" Left Should be attached");
            HandJoint = AttachedHand.gameObject.AddComponent<SpringJoint>();
            HandJoint.connectedBody = col.rigidbody;
            HandJoint.spring = 5000;
            HandJoint.tolerance = 0;
            HandJoint.enablePreprocessing = false;
            
            //HandJoint.connectedBody.gameObject.layer = 8;
            Attached = true;

            
        }
        /*
        if (spRight == null && !rightAttached && Input.GetAxis("XboxRightTrigger") > 0)
        {
            Debug.Log(" Right Should be attached");
            spRight = rightHand.gameObject.AddComponent<SpringJoint>();
            spRight.connectedBody = col.rigidbody;
            spRight.spring = 12000;
            spRight.breakForce = Force;
            rightAttached = true;
        }*/
        
    }

    private void ReleaseGrip()
    {
        
        if(Attached && Input.GetAxis("XboxRightTrigger") == 0)
        {
            Debug.Log("Release!!");
            Destroy(HandJoint);
            //Destroy(spRight);
            Attached = false;
                //rightAttached = false;
            
        }
    }

    

    //private void OnJointBreak()
    //{
    //    attached = false;
    //}
    // Update is called once per frame
    void Update()
    {

        //if (Input.GetAxis("XboxRightTrigger") > 0)
        //{
        //    Debug.Log("serhserh");
        //}
        ReleaseGrip();
        if (_Input.magnitude > Mathf.Epsilon)
        {
            
            AttachedHand.AddForce(_Input * MoveSpeed, ForceMode.Acceleration);
            //rightHand.AddForce(_Input * MoveSpeed, ForceMode.Acceleration);
        }
    }
}
