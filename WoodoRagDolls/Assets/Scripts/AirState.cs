using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/States/AirState")]
public class AirState : State {

    private PlayerController _controller;
    // Use this for initialization

    public override void Initialize(Controller owner)
    {
        _controller = (PlayerController)owner;
    }

    public override void Update()
    {
        
    }
}
