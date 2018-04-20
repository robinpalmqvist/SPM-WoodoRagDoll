using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform[] Targets;
    public float OrtoGraphicSize;
    public float SmoothingTime;
    public MinMaxFloat Zoom;
    public Vector2 Padding;
    
    public float ScreenEdgeCut;
    public GameObject TestPrefab;

    private Vector3 _centerPosition;
    private Vector3 _currentVelocity;
    private Vector3 offset;
    private Camera _camera;
    private Vector3 _rightVector;
    private Vector3 _forwardVector;
    
    Quaternion rotation;

    private float _ortho;


    // Use this for initialization
    void Start()
    {
        _camera = GetComponentInChildren<Camera>();
        _camera.orthographicSize = OrtoGraphicSize;

        foreach (Transform tr in Targets)
        {
            _centerPosition += tr.position;
        }
        _centerPosition /= Targets.Length;

        transform.position = _centerPosition;

        float ortho = _camera.orthographicSize * _camera.aspect;
        float y = Camera.main.transform.rotation.eulerAngles.y;
        rotation = Quaternion.Euler(0, y, 0);
        
        
       

            //GameObject.Instantiate(TestPrefab, currentScreenMax, Quaternion.identity, null);
    




        }

    // Update is called once per frame
    void Update()
    {
        UpdateScreenBoundaries();
        
       
    }

    private void UpdateScreenBoundaries()
    {
      









    }
  


    private void LateUpdate()
    {
        UpdateMovement();
        FindZoomValue();

    }

    private void UpdateMovement()
    {

        _centerPosition = FindCenterLocation();
        transform.position = Vector3.SmoothDamp(transform.position, _centerPosition, ref _currentVelocity, SmoothingTime);


    }

    private Vector3 FindCenterLocation()
    {
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

    private float FindZoomValue()
    {

        float size = 0;
        Vector3 localCenterPosition = transform.InverseTransformPoint(_centerPosition);
        //Debug.Log("Local: " + localCenterPosition + " World: " + _centerPosition);
        return size;
    }
}
