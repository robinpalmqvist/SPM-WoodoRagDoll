using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePrefab : MonoBehaviour {

    public GameObject handsFree, sword;
    public CameraFollow camerafollow;

    // Use this for initialization

    

    void Start () {

        sword.SetActive(false);
        handsFree.SetActive(true);
        camerafollow.Targets[0] = handsFree.transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            sword.transform.position = handsFree.transform.position;
            handsFree.SetActive(false);
            sword.SetActive(true);
            camerafollow.Targets[0] = sword.transform;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            handsFree.transform.position = sword.transform.position;
            sword.SetActive(false);
            handsFree.SetActive(true);
            camerafollow.Targets[0] = handsFree.transform;


        }
    }
}
