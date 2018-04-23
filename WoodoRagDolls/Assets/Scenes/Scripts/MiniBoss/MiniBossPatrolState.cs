using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/MiniBoss/PatrolState")]
public class MiniBossPatrolState : State
{

    [Header("Patrolling")]
    public float PatrolSpeed;
    public float DetectionRadius;
    public MinMaxFloat PatrollingDistance;
    public float FieldOfView;
    public float DirectionTimer;
    public MinMaxFloat PausingTime;
    public float RotationSpeed;

    private MiniBossController _controller;
    private Vector3 _direction;
    private float _directionTimer;
    private float _currentPause;
    private bool _canMove;


    


    [SerializeField]
    private bool _isInCombat;
    private Transform[] _targets { get { return _controller.Targets; } }


    public override void Initialize(Controller owner)
    {
        _controller = (MiniBossController)owner;


    }
    public override void Update()
    {
        PerformRotation();
        UpdatePatrolMovement();
    }



    public override void Enter()
    {
        _directionTimer = DirectionTimer;
        _directionTimer += Time.time;
        _currentPause = Random.Range(PausingTime.Min, PausingTime.Max) + Time.time;
        Debug.Log("Enter is running in patrol");



    }

    public override void Exit()
    {

    }

    private void PerformRotation()
    {
        
        if(Time.time < _directionTimer)
        {
            return;
        }
        float rotation = 45f;
        Quaternion rot = Quaternion.Euler(0, rotation, 0);

        CoroutineHandeler.instance.StartCoroutine(CoroutineHandeler.instance.RotateMiniBoss(rot, transform, RotationSpeed));
        _direction = transform.forward * PatrollingDistance.Min;

        _directionTimer += Time.time;

    }

    private void UpdatePatrolMovement()
    {
        if (Time.time < _currentPause)
        {
            return;
        }
       

    }
    private void DetectCollision()
    {

    }

}
