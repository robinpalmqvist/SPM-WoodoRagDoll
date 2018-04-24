using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Blommis/PausState")]
public class BlommisPausState : State
{
    public float pausBetweenFire;
    private float paus;

    private BlommisController _controller;

    public override void Initialize(Controller owner)
    {
        _controller = (BlommisController)owner;
    }

    public override void Enter()
    {
        // TODO: remove debug.
        Debug.Log("I found you!!");
        paus = pausBetweenFire;
    }

    public override void Update()
    {
        transform.LookAt(_controller.target, Vector3.up);
        //_controller.LerpFireColor();

        paus -= Time.deltaTime;
        if (paus < 0)
        {
            _controller.TransitionTo<BlommisFireState>();
            return;
        }

        Collider[] targets = Physics.OverlapSphere(transform.position, _controller.radius, _controller.layerMask);
        if (targets.Length == 0)
        {
            _controller.TransitionTo<BlommisIdleState>();
            return;
        }
    }

    public override void Exit()
    {

    }
}
