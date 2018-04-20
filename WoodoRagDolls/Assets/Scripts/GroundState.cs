using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/States/Ground")]
public class GroundState : State {

    private PlayerController _controller;

    [Header("Jumping")]
    public MinMaxFloat JumpHeight;

    [Header("Movement")]
    public float MoveSpeed;
    public float Deacceleration = 0.1f;
    public float MaxSpeed = 5f;
    

    private Vector3 _groundNormal;
    private float Jump = 40f;




    private Vector3 ForwardAlongGround
    {
        get
        {
            float y = Camera.main.transform.rotation.eulerAngles.y;
            // float y = transform.rotation.eulerAngles.y;
            return Quaternion.Euler(90f, y, 0.0f) * _groundNormal;
        }
    }


    public override void Initialize(Controller owner)
	{
        _controller = (PlayerController)owner;
        
	}

	public override void Enter()
	{
       
        
	}

	public override void Exit()
	{
        
	}

	public override void Update()
	{
        UpdateJump();
        UpdateMovement();
       

    }

    private void UpdateMovement()
    {
        Vector3 input = _controller.Input;
        //Debug.Log(input);


        //Vector3 cameraForward = Camera.main.transform.forward;
        //cameraForward.y = 0.0f;
        
        

        //float angle = Vector3.SignedAngle(input, cameraForward, Vector3.up);
        if (input.magnitude > Mathf.Epsilon)
        {
            //_controller.rb.rotation = Quaternion.Euler(0f, input.y, 0f);
            //_controller.rb.MoveRotation(Quaternion.Euler(0f, input.y, 0f));
            _controller.rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            _controller.transform.forward = input;
            _controller.rb.AddForce(input * MoveSpeed, ForceMode.Acceleration);
            _controller.rb.velocity = Vector3.ClampMagnitude(_controller.rb.velocity, MaxSpeed);

        } else
        {
            _controller.rb.velocity = _controller.rb.velocity * Deacceleration;
            _controller.rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        //_controller.controller.Move(input * Time.deltaTime * MoveSpeed);
        //_controller.rb.AddForce(input * MoveSpeed, ForceMode.Acceleration);
        

        //Debug.Log(_controller.rb.velocity);
       // _controller.transform.rotation = Quaternion.Euler(0, -angle, 0);
        //Vector3 delta = Quaternion.AngleAxis(angle, -_groundNormal) * ForwardAlongGround * MoveSpeed * Time.deltaTime;
        
        //Debug.Log(angle);
        
       
    }

    private void UpdateJump()
    {
        if (Input.GetButtonDown("XboxJumpA"))
        {
            Debug.Log("A button");
            _controller.rb.AddForce(0f, Jump * 20f, 0f, ForceMode.Impulse);
        }
    }

    private void UpdateGroundNormal()
    {
        
    }

}
