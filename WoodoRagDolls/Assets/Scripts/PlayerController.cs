using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Controller {

    //public CharacterController controller;
    //public Transform _transform;
    public Rigidbody rb;
    public int CollisionLayers = ~(1 << 8);
    public float GroundCheckDistance = 0.3f;

    private CapsuleCollider _collider;
    
    //private float _force = 20;

    [Range(0f, 1f)] public float InputRequiredToMove = 0.3f;

    public Vector3 Input
    {
        get
        {

            Vector3 input = new Vector3(UnityEngine.Input.GetAxisRaw("LeftStickHorizontal"), 0.0f, UnityEngine.Input.GetAxisRaw("LeftStickVertical"));


            float y = Camera.main.transform.rotation.eulerAngles.y;
            input = Quaternion.Euler(0f, y, 0f) * input;
            return input.normalized;

        }
    }

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
    }

    public RaycastHit[] DetectHits()
    {
        //Eventuellt bör bättre uträkning göras för att hitta punkt på capsulecollider
        Vector3 colliderHeight = _collider.transform.position;
        colliderHeight.y = colliderHeight.y - (_collider.height / 4);

        // för testning, visar raylängd
        Vector3 test = colliderHeight;
        test.y -= GroundCheckDistance;
        

        RaycastHit[] groundHits = Physics.SphereCastAll(colliderHeight, _collider.radius, Vector3.down, GroundCheckDistance, CollisionLayers);
        //RaycastHit[] groundHits = Physics.CapsuleCastAll(colliderHeight, test, _collider.radius, Vector3.down, 50f, CollisionLayers);

        Debug.DrawLine(colliderHeight, test);
        //Debug.DrawRay(colliderHeight, Vector3.down);
        

        //Debug.Log(groundHits.Length);
        
        return groundHits;
    }
}
