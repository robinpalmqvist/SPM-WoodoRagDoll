using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/States/AirState")]
public class AirState : State {

    private PlayerController _controller;
    // Use this for initialization

    [Header("Movement")]
    public float MoveSpeed;
    public float AirDeacceleration = 0.1f;
    public float MaxSpeed = 5f;

    public Vector3 FastFall;

    [HideInInspector] public bool CanCancelJump = false;

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Enter()
    {
        Debug.Log("AirState");
    }
    public override void Update()
    {
        
        UpdateGroundCheck();

    }

    public override void FixedUpdate()
    {
        CancelJump();
        UpdateMovement();
        UpdateFastFalling();
    }

    private void UpdateGroundCheck()
    {
        RaycastHit[] hits = _controller.DetectHits();

        if(hits.Length > 0)
        {
            _controller.TransitionTo<GroundState>();
        }
    }

    private void UpdateMovement()
    {
        Vector3 input = _controller.Input;

        if (input.magnitude > Mathf.Epsilon)
        {

            //_controller.rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            _controller.transform.forward = input;
            _controller.rb.AddForce(input * MoveSpeed, ForceMode.Acceleration);
            _controller.rb.velocity = Vector3.ClampMagnitude(_controller.rb.velocity, MaxSpeed);

        }
        else
        {
            //_controller.rb.velocity = _controller.rb.velocity * AirDeacceleration;
            //_controller.rb.constraints = RigidbodyConstraints.FreezeRotation;
        }


    }

    private void UpdateFastFalling()
    {

        //float multiplier = _controller.rb.velocity.y > 0.0f ? 1.0f : FastFall.y;
        //_controller.rb.velocity += Vector3.down * multiplier * Time.deltaTime;


        if (_controller.rb.velocity.y < 0f)
        {
            _controller.rb.AddForce(FastFall, ForceMode.Impulse);
        }

    }

    private void CancelJump()
    {
        
        if (Input.GetButton("XboxJumpRightBumper") || Input.GetButton("Jump")){
            return;
        }

        if (_controller.rb.velocity.y < Mathf.Epsilon)
        {
            CanCancelJump = false;
        }

        if (CanCancelJump)
        {
            Debug.Log("CancelJump");
            _controller.rb.AddForce(FastFall * 20, ForceMode.Impulse);
            CanCancelJump = false;
        }

    }

}
