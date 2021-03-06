﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("CameraFollow")]
    public Transform[] Targets;
    public float OrtoGraphicSize;
    public float MovementSmoothing;

    [Header("Zoom")]
    public MinMaxFloat Zoom;
    public float ZoomSmoothing;

    public Material AlwaysVisible;


    //Variables for Centering Camera
    private Vector3 _centerPosition;
    private Vector3 _currentVelocityTowardsCenter;

    private Camera _camera;

    //Variables for ZoomControl
    private Bounds _bounds;
    private float _greatestDistance;
    private float _currentZoomVelocity;
    






    // Use this for initialization
    void Start()
    {


        _camera = GetComponentInChildren<Camera>();
        _camera.orthographicSize = Zoom.Max;

        foreach (Transform tr in Targets)
        {
            _centerPosition += tr.position;
        }
        _centerPosition /= Targets.Length;

        transform.position = _centerPosition;


    }


    void Update()
    {


        
        _greatestDistance = FindGreatestDistanceBetweenPlayers();
        






    }
    private void UpdateBounds()
    {
        
        Bounds bounds = new Bounds();

        foreach (Transform t in Targets)
        {
            bounds.Encapsulate(t.position);
        }
    }

    private void UpdateScreenBoundaries()
    {
        if(Targets.Length <= 1)
        {
            return;
        }
        
        for (int i = 0; i < Targets.Length; i++)
        {
            Vector3 playerInViewPortCoords = _camera.WorldToViewportPoint(Targets[i].position);
            float z = Mathf.Clamp01(playerInViewPortCoords.y);
            float x = Mathf.Clamp01(playerInViewPortCoords.x);

            Vector3 ClampedPos = _camera.ViewportToWorldPoint(new Vector3(x, z, playerInViewPortCoords.z));
            Targets[i].position = new Vector3(ClampedPos.x, Targets[0].position.y, ClampedPos.z);
        }


    }



    private void LateUpdate()
    {
        UpdateMovement();
        UpdateZoom();
        UpdateScreenBoundaries();

    }

    private void UpdateMovement()
    {

        _centerPosition = FindCenterLocation();
       
        transform.position = Vector3.SmoothDamp(transform.position, _centerPosition, ref _currentVelocityTowardsCenter, MovementSmoothing);
        //Debug.Log(_centerPosition);


    }

    private void UpdateZoom()
    {
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, Mathf.Lerp(Zoom.Min, Zoom.Max, _greatestDistance / (Zoom.Min + Zoom.Max)), ref _currentZoomVelocity, ZoomSmoothing);
    }

    private Vector3 FindCenterLocation()
    {
        if (Targets.Length == 1)
        {
            return Targets[0].position;
        }
        Vector3 center = Vector3.zero;
        int numTargets = 0;
        foreach (Transform tr in Targets)
        {
            if (tr.gameObject.activeSelf)
            {
                center += tr.position;
                numTargets++;
            }
        }
        return center /= numTargets;

    }

    private float FindGreatestDistanceBetweenPlayers()
    {
        if(Targets.Length == 1)
        {
            return 0.0f;
        }
        _bounds = new Bounds(transform.position, Vector3.zero);

        foreach (Transform t in Targets)
        {
            _bounds.Encapsulate(t.position);
        }


        return Mathf.Max(_bounds.size.x, _bounds.size.z);
    }
}
