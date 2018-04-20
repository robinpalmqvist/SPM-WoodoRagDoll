using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Blommis/IdleState")]
public class BlommisIdleState : State {

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
        Collider[] targets = Physics.OverlapSphere(transform.position, _controller.radius, _controller.layerMask);
        if (targets.Length > 0)
        {
            Debug.Log(targets[0].name);
            _controller.target = targets[0].transform;
            _controller.TransitionTo<BlommisPausState>();
            return;
        }
        // TODO: remove debug.
        Debug.Log("Can't see you");
    }

    public override void Exit()
    {

    }
}
