using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/States/Ground")]
public class GroundState : State {

    private PlayerController _controller;

    public MinMaxFloat JumpHeight;


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
        
	}

}
