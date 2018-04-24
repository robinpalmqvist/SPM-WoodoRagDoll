using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Push/Idle")]
public class IdleState : State {

    private EnemyPushController _controller;
    public LayerMask playerMask;

    public float detectionRadius;

    private float entryTime;
    private float idleTime = 3f;

    public override void Initialize(Controller owner)
    {
        _controller = (EnemyPushController)owner;

    }

    public override void Enter(){
        entryTime = Time.time;
    }

    public override void Exit(){
        
    }

    public override void Update(){

        if (_controller.Health <= 0){
            _controller.TransitionTo<DeathState>();
            return;
        }

        if(Time.time > entryTime + idleTime){
            _controller.TransitionTo<PatrolState>();
            return;
        }

        SearchForPlayers();

    }

    private void SearchForPlayers(){
        Collider[] players = Physics.OverlapSphere(transform.position, detectionRadius, playerMask);
        if (players.Length == 0)
            return;

        int index = Random.Range(0, players.Length - 1);

        _controller.GetState<ChargeState>().target = players[index].transform;

        _controller.TransitionTo<ChargeState>();
    }



}
