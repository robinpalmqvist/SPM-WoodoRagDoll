using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Blommis/DefeatState")]
public class BlommisDefeatState : State {

    private BlommisController _controller;
    

    public override void Initialize(Controller owner)
    {
        _controller = (BlommisController)owner;
    }

    public override void Enter()
    {

    }

    public override void Update()
    {

    }

    public override void Exit()
    {

    }
}
