using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPushController : Controller {

    [Header("Movement")]
    public float MaxSpeed = 10f;

    public int Health = 100;

    public Rigidbody enemyRb;

    public NavMeshAgent agent;

    public RaycastHit[] GroundCheck(){

        RaycastHit[] hits = Physics.RaycastAll(transform.position + (transform.forward * 2), -transform.up, 1.5f);

        Debug.DrawRay(transform.position + (transform.forward * 2), -transform.up * 1.5f);

        return hits;
    }

	public void OnCollisionEnter(Collision collision)
	{
        //if (collision.gameObject.CompareTag("Sword")){
        //    Health -= 20;
        //    Debug.Log(Health);
        //}
	}

}
