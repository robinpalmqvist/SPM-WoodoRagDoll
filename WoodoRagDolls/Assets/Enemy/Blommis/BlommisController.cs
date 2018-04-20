using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlommisController : Controller
{
    public LayerMask layerMask;
    public Transform target;
    public float radius = 20f;

    [Header ("Material Pulse")]
    public Material baseMaterial;
    public Material fireMaterial;
    [HideInInspector]public float duration = 0.3f;
    public Renderer rend;


    // Detectionarea
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    public void LerpFireColor()
    {
        Debug.Log("Lerpu");
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.Lerp(baseMaterial, fireMaterial, lerp);
    }

    public void ResetColor()
    {
        rend.material = baseMaterial;
    }
}
