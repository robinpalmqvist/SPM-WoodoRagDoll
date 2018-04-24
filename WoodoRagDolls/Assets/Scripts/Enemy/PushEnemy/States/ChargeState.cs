using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Push/Charge")]
public class ChargeState : State {

    [HideInInspector] public Transform target = null;

    private EnemyPushController _controller;

    public float chargeUpTime = 3f;

    public float chargeSpeed = 20f;

    public float maxChargeDistance = 30f;

    private Vector3 startPosition;

    public LayerMask layerMask;

    private float entryTime;

    private Vector3 normalizeDirection;

    private bool attacking = false;

    public override void Initialize(Controller owner)
    {
        _controller = (EnemyPushController)owner;

    }

    public override void Enter()
    {
        _controller.agent.ResetPath();
        startPosition = transform.position;
        entryTime = Time.time;
        _controller.agent.speed = 20;
        _controller.agent.acceleration = 100;
    }

    public override void Exit()
    {
        _controller.agent.speed = 3.5f;
        _controller.agent.acceleration = 8;
    }

    public override void Update()
    {
        if (_controller.Health <= 0)
        {
            _controller.TransitionTo<DeathState>();
            return;
        }

        RaycastHit[] hits = _controller.GroundCheck();
        if (hits.Length == 0){
            Debug.Log("Helloasfgsz");
            //_controller.agent.ResetPath();
            entryTime = Time.time;
            return;
        }


        if (Time.time < entryTime + chargeUpTime){
            transform.LookAt(target.position);

            normalizeDirection = (target.position - transform.position).normalized;
            //transform.forward = normalizeDirection;
            attacking = true;
            return;
        } else if (attacking){
            
            _controller.agent.destination = target.position + (normalizeDirection * 5);
            attacking = false;
        }

        //_controller.agent.velocity = normalizeDirection * 10;


        //transform.position += normalizeDirection * chargeSpeed * Time.deltaTime;

        //transform.LookAt(normalizeDirection);

        CheckForHits();


    }

    private void CheckForHits(){

        Debug.DrawRay(transform.position, transform.forward * 1.5f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                
            }

            //_controller.TransitionTo<IdleState>();
            entryTime = Time.time;
        }
        else if (Vector3.Distance(startPosition, transform.position) > maxChargeDistance)
        {
            //_controller.TransitionTo<IdleState>();
            entryTime = Time.time;
        }
        else if (Vector3.Distance(transform.position, _controller.agent.destination) < 2){
            entryTime = Time.time;
        }

    }

}
