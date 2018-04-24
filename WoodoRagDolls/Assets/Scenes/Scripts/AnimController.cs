using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {

    public Rigidbody[] bodyParts;
    private Animator anim;
    public GameObject Sword;
    private bool isActive = false;
    // Use this for initialization
    private void Awake()
    {
        bodyParts = gameObject.GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        Sword.SetActive(false);
        anim.enabled = false;
    }
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("XboxXButton") && !isActive)
        {
            anim.enabled = true;
            Debug.Log("XButton");
            anim.SetBool("ActivateSword", true);
            isActive = true;
            StartCoroutine(AnimationWait());


            

        } else if (Input.GetButtonDown("XboxXButton") && isActive)
        {
            isActive = false;
            Sword.SetActive(false);
        }
	}

    IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(0.2f);
        anim.enabled = false;
    }
}
