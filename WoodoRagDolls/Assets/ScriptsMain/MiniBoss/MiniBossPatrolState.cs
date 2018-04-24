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
   
   

    private MiniBossController _controller;
    private Vector3 _direction;
    private Vector3 _previousPos;
   


    


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
        Debug.Log(Vector3.Distance(transform.position, _direction));
        if(Vector3.Distance(transform.position, _direction) > Mathf.Epsilon) { 
        UpdatePatrolMovement();

        }
    }



    public override void Enter()
    {
        float rotation = Random.Range(45, 90);
        Quaternion rot = Quaternion.Euler(0, rotation, 0);
        _direction = rot * transform.forward * PatrollingDistance.Min;
        _previousPos = transform.position;
        Debug.Log(_previousPos);
        Debug.Log(_direction);

        


    }

    public override void Exit()
    {

    }

    private void PerformRotation()
    {
        
      

    }

    private void UpdatePatrolMovement()
    {

        _controller.Character.Move(_direction * Time.deltaTime);

    }
    private void DetectCollision()
    {

    }

}
