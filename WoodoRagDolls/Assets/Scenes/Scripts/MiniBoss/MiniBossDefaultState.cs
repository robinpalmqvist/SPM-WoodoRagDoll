using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/MiniBoss/PatrolState")]
public class MiniBossDefaultState : State
{

    [Header("Patrolling")]
    public float PatrolSpeed;
    public float DetectionRadius;
    public MinMaxFloat PatrollingDistance;
    public float FieldOfView;
    public float DirectionTimer;

    private MiniBossController _controller;
    private Vector3 _direction;


    [SerializeField]
    private bool _isInCombat;
    private Transform[] _targets { get { return _controller.Targets; } }


    public override void Initialize(Controller owner)
    {
        _controller = (MiniBossController)owner;

    }
    public override void Update()
    {
        GetRandomPatrollingDirection();
        UpdatePatrolMovement();

    }


    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    private void GetRandomPatrollingDirection()
    {
        if (Time.time < DirectionTimer)
        {
            return;
        }
        float rotation = Random.Range(0, 360);
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);

        _direction = rotation * Vector3.forward;

    }

    private void UpdatePatrolMovement()
    {
        _controller.Character.Move(_direction * Random.Range(PatrollingDistance.Min, PatrollingDistance.Max) * PatrolSpeed * Time.deltaTime);

    }
    private void DetectCollision()
    {

    }

}
