using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tower : MonoBehaviour
{
    
    public float range = 10f;  // Range of the tower
    public float fireRate = 1f;  // Time between shots
    public GameObject bulletPrefab;  // Prefab of the bullet
    public Transform firePoint;  // Point where the bullets will be fired from

    private float fireCountdown = 0f;  // Countdown until next shot
    public GameObject nearestEnemy = null;  // Nearest enemy to the tower
    public GameObject wizard;
    public float animationSpeed=1;
    private Animator _animator;


    private void Awake()
    {
        
        _animator = wizard.GetComponent<Animator>();
    }

    // Function to find the nearest enemy to the tower
    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");  // Find all enemies with the tag "Enemy"
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
    }

    private void Update()
    {
        if (nearestEnemy == null)
        {
            FindNearestEnemy();
            return;
        }

        float distanceToEnemy = Vector3.Distance(transform.position, nearestEnemy.transform.position);

        if (distanceToEnemy > range)
        {
            nearestEnemy = null;
            return;
        }

        // Check if it's time to fire
        if (fireCountdown <= 0f)
        {
            wizard.transform.DOLookAt(nearestEnemy.transform.position, 0.5f);
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        
        fireCountdown -= Time.deltaTime;
    }

    // Function to shoot at the nearest enemy
    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        int layerIndex = 0;
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(layerIndex);
        if (bullet != null)
        {
            _animator.SetBool("isAttack",true);
            _animator.speed = animationSpeed;
            bullet.Seek(nearestEnemy.transform);
            
        }
        if (stateInfo.IsName("Attack")&& stateInfo.normalizedTime>=1)
        {
            _animator.SetBool("isAttack",false);
        }
    }

    // Draw the range of the tower in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    
}
