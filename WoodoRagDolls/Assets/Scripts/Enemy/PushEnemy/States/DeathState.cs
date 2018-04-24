using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Push/Death")]
public class DeathState : State {

    private EnemyPushController _controller;

    public override void Initialize(Controller owner)
    {
        _controller = (EnemyPushController)owner;

    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update(){
        
    }


}
