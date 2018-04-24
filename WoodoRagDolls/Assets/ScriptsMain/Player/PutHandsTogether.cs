using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutHandsTogether : MonoBehaviour {

    public Rigidbody right, left;
    private SpringJoint sp;
	// Use this for initialization
	void Start () {
		
	}

    private void HandsTogether()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Connected");
            sp = right.gameObject.AddComponent<SpringJoint>();
            sp.connectedBody = left;
            sp.spring = 12000;

        }
    }

    // Update is called once per frame
    void Update () {

        HandsTogether();
	}
}
