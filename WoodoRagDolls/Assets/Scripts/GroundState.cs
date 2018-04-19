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

    private Vector3 _groundNormal;




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
        UpdateMovement();
       

    }

    private void UpdateMovement()
    {
        Vector3 input = _controller.Input;
        Debug.Log(input);
        _controller.controller.Move(input * Time.deltaTime * MoveSpeed);
        
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0.0f;


        float angle = Vector3.SignedAngle(input, cameraForward, Vector3.up);
        Debug.Log(angle);
        _controller.transform.rotation = Quaternion.Euler(0, -angle, 0);
        //Vector3 delta = Quaternion.AngleAxis(angle, -_groundNormal) * ForwardAlongGround * MoveSpeed * Time.deltaTime;
        
        //Debug.Log(angle);
        
       
    }

    private void UpdateGroundNormal()
    {
        
    }

}
