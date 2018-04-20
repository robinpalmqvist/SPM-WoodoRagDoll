using System.Collections;
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

    public Material BlendMaterial;

   

    public GameObject TestPrefab;

    //Variables for Centering Camera
    private Vector3 _centerPosition;
    private Vector3 _currentVelocityTowardsCenter;
    
    private Camera _camera;
   
    //Variables for ZoomControl
    private Bounds _bounds;
    private float _greatestDistance;
    private float _currentZoomVelocity;
    Quaternion rotation;
    Quaternion cameraRot;

   

   


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

        
        float y = transform.rotation.eulerAngles.y;
        rotation = Quaternion.Euler(0, -y, 0);
        cameraRot = Quaternion.Euler(_camera.transform.eulerAngles.x, 0, 0);




        GameObject.Instantiate(TestPrefab, rotation * Vector3.one, Quaternion.identity, null);





    }

    
    void Update()
    {

        float y = transform.rotation.eulerAngles.y;
        rotation = Quaternion.Euler(0, -y, 0);
        UpdateScreenBoundaries();
        _greatestDistance = FindGreatestDistanceBetweenPlayers();
        BlendMaterial.SetFloat("_LerpValue", 1+ Mathf.Sin(Time.time));
        
       
        


    }
    private void UpdateBounds()
    {
        if(Targets.Length <= 1)
        {
            return;
        }
        Bounds bounds = new Bounds();

        foreach (Transform t in Targets)
        {
            bounds.Encapsulate(t.position);
        }
    }

    private void UpdateScreenBoundaries()
    {

        RaycastHit hit;
        Vector3 direction = (Targets[0].position - _camera.transform.position).normalized;
        Physics.Raycast(_camera.transform.position, direction, out hit, Mathf.Infinity);




    }



    private void LateUpdate()
    {
        UpdateMovement();
        UpdateZoom();
        

    }

    private void UpdateMovement()
    {

        _centerPosition = FindCenterLocation();
        transform.position = Vector3.SmoothDamp(transform.position, _centerPosition, ref _currentVelocityTowardsCenter, MovementSmoothing);


    }

    private void UpdateZoom()
    {
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, Mathf.Lerp(Zoom.Min, Zoom.Max, _greatestDistance / (Zoom.Min + Zoom.Max)), ref _currentZoomVelocity, ZoomSmoothing);
    }

    private Vector3 FindCenterLocation()
    {
        if(Targets.Length == 1)
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
      
         _bounds = new Bounds(transform.position, Vector3.zero);

        foreach (Transform t in Targets)
        {
            _bounds.Encapsulate(t.position);
        }
       

        return Mathf.Max(_bounds.size.x, _bounds.size.z);
    }
}
