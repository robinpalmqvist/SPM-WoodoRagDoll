using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPalm : MonoBehaviour {

    public float Force = 4000;
    public Rigidbody leftHand, rightHand;
    private bool attached = false;
    private float MoveSpeed = 100f;

    [Range(0f, 1f)] public float InputRequiredToMove = 0.3f;

    public Vector3 Input
    {
        get
        {
            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("RightStickHorizontal"), 0.0f, UnityEngine.Input.GetAxisRaw("RightStickVertical"));

            float y = Camera.main.transform.rotation.eulerAngles.y;
            input = Quaternion.Euler(0f, y, 0f) * input;
            return input.normalized;

        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (!attached)
        {
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
        if (Input.magnitude > Mathf.Epsilon)
        {
            leftHand.AddForce(Input * MoveSpeed, ForceMode.Acceleration);
            rightHand.AddForce(Input * MoveSpeed, ForceMode.Acceleration);
        }
    }
}
