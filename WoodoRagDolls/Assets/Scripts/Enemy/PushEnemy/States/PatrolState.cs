using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Enemy/Push/Patrol")]
public class PatrolState : State {

    private EnemyPushController _controller;

    public float walkRadius = 20f;

    public LayerMask playerMask;

    public float detectionRadius;

    private Vector3 finalPosition;

    private NavMeshHit hit;

    public override void Initialize(Controller owner)
    {
        _controller = (EnemyPushController)owner;

    }

    public override void Enter()
    {

        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;

        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        finalPosition = hit.position;

        _controller.agent.destination = finalPosition;

    }

    public override void Exit()
    {

    }

    public override void Update()
    {

        if (Vector3.Distance(transform.position, finalPosition) < 1.1f){
            _controller.TransitionTo<IdleState>();
            return;
        }

        SearchForPlayers();

    }

    private void SearchForPlayers()
    {
        Collider[] players = Physics.OverlapSphere(transform.position, detectionRadius, playerMask);
        if (players.Length == 0)
            return;

        int index = Random.Range(0, players.Length - 1);

        _controller.GetState<ChargeState>().target = players[index].transform;

        _controller.TransitionTo<ChargeState>();
    }

}
