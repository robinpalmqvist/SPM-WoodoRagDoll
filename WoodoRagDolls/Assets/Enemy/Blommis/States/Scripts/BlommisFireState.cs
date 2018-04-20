using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Blommis/FireState")]
public class BlommisFireState : State {

    private BlommisController _controller;
    public GameObject[] projectiles;
    //public float timeBetweenShots;
    public GameObject projectile;
    //public float projectileSpeed;
    //private Vector3 projectileTarget;

    private int currentProjectile;

    //private bool shooting = false;

    public float projectilePaus;
    private float paus;

    //public float projectilesPerPulse;
 
    public override void Initialize(Controller owner)
    {
        _controller = (BlommisController)owner;

        for (int i = 0; i < projectiles.Length; i++)
        {
            GameObject tempProjectile = Instantiate(projectile);
            tempProjectile.transform.position = transform.position;
            tempProjectile.SetActive(false);
            projectiles[i] = tempProjectile;
        }
        _controller.duration = projectilePaus;
    }

    public override void Enter()
    {
        if (currentProjectile == projectiles.Length - 1)
        {
            ResetProjectiles();
        }
        currentProjectile = 0;
        //_controller.ResetColor();
    }

    public override void Update()
    {
        transform.LookAt(_controller.target, Vector3.up);
 
        paus -= Time.deltaTime;
        if (paus < 0)
        {
            // TODO: remove debug.
            Debug.Log("pew");
            projectiles[currentProjectile].GetComponent<ProjectileScript>().Activate(SetTarget());
            if (currentProjectile < projectiles.Length - 1)
            {
                currentProjectile++;
                paus = projectilePaus;
            }
            else
            {
                _controller.TransitionTo<BlommisPausState>();
            }         
        }
    }

    public override void Exit()
    {

    }

    private Vector3 SetTarget()
    {
        return new Vector3(_controller.target.transform.position.x, _controller.target.transform.position.y, _controller.target.transform.position.z);
    }

    private void ResetProjectiles()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            projectiles[i].transform.position = transform.position;
        }
    }
}
