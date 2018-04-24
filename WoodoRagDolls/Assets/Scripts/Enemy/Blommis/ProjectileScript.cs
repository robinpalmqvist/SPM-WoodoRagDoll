using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public bool moving = false;
    public float projectileSpeed;
    private Vector3 direction;
    private Vector3 previousPosition;
    public float maxDistance;
    //public GameObject flower;
    private bool impact = false;
    public float maxDistRay;
    public LayerMask layerMask;
    

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (moving)
        {
            transform.position += direction * projectileSpeed * Time.deltaTime;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, maxDistRay, layerMask))
            {
                if (hit.collider != null)
                {
                    Debug.Log("Impact point: " + hit.collider.gameObject.name);
                    hit.rigidbody.AddForce(direction * 100, ForceMode.VelocityChange);
                    impact = true;
                }
            }

            if (impact || Vector3.Distance(previousPosition, transform.position) > maxDistance)
            {
                gameObject.SetActive(false);
                moving = false;
                impact = false;
            }
        }
    }

    public void Activate(Vector3 target)
    {
        previousPosition = transform.position;
        gameObject.SetActive(true);
        direction = (target - transform.position).normalized;
        moving = true;
    }
}
