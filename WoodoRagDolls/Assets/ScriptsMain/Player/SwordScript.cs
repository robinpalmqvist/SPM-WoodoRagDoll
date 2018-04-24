using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    public GameObject activeSword, idleSword;
    private bool isActive = false;
	// Use this for initialization
	void Start () {
        activeSword.SetActive(false);
        idleSword.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("XboxXButton") && !isActive)
        {

            activeSword.SetActive(true);
            idleSword.SetActive(false);
            isActive = true;

        }
        else if (Input.GetButtonDown("XboxXButton") && isActive)
        {
            
            activeSword.SetActive(false);
            idleSword.SetActive(true);
            isActive = false;
        }
    }
}
