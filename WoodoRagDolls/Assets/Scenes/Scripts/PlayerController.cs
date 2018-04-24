using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerController : Controller {

    //public CharacterController controller;
    //public Transform _transform;
    public Rigidbody rb;
    public int CollisionLayers = ~(1 << 8);
    public float GroundCheckDistance = 0.05f;

    private Rigidbody[] rigidbodyparts;

    private CapsuleCollider _collider;
    
    //private float _force = 20;

    [Range(0f, 1f)] public float InputRequiredToMove = 0.3f;

    public Vector3 Input
    {
        get
        {

            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("LeftStickHorizontal"), 0.0f, UnityEngine.Input.GetAxisRaw("LeftStickVertical"));

            //Datorkontroll
            //Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), 0.0f, UnityEngine.Input.GetAxisRaw("Vertical"));

            float y = Camera.main.transform.rotation.eulerAngles.y;
            input = Quaternion.Euler(0f, y, 0f) * input;
            return input.normalized;

        }
    }

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();

        rigidbodyparts = gameObject.transform.parent.GetComponentsInChildren<Rigidbody>();
        //rigidbodyparts = GameObject.Find("RagdollPrefab").GetComponentsInChildren<Rigidbody>();
    }

    public RaycastHit[] DetectHits()
    {
        //Eventuellt bör bättre uträkning göras för att hitta punkt på capsulecollider
        Vector3 colliderHeight = _collider.transform.position;
        //colliderHeight.y = colliderHeight.y - (_collider.height / 4);

        // för testning, visar raylängd
        Vector3 test = colliderHeight;
        test.y -= GroundCheckDistance;

        
        List<RaycastHit> groundHits = Physics.RaycastAll(colliderHeight, Vector3.down, GroundCheckDistance, CollisionLayers).ToList();
        //List<RaycastHit> groundHits = Physics.SphereCastAll(colliderHeight, _collider.radius, Vector3.down, GroundCheckDistance, CollisionLayers).ToList();
        //RaycastHit[] groundHits = Physics.CapsuleCastAll(colliderHeight, test, _collider.radius, Vector3.down, 50f, CollisionLayers);

        Debug.DrawLine(colliderHeight, test);
        //Debug.DrawRay(colliderHeight, Vector3.down);
        

        //Debug.Log(groundHits.Length);
        
        return groundHits.ToArray();
    }

    public void SetRigidYVelocity(float yVelocity){

        foreach(Rigidbody r in rigidbodyparts){

            Vector3 v = r.velocity;
            v.y = yVelocity;
            r.velocity = v;

        }
    }
}
