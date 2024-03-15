using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform spawnPoint;
    private Animator _animator;
    public float spawnTime;
    private Transform tower;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        tower = GameObject.FindGameObjectWithTag("Tower").GetComponent<Transform>();
    }

    private void Update()
    {
        if (GetComponent<Enemy>()._isdead==true)
        {
            Destroy(GetComponent<Archer>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stop"))
        {
            GetComponent<Enemy>().speed = 0;
            _animator.SetBool("isAttack",true);
            InvokeRepeating("ArrowInstantiate",1f,spawnTime);
            
        }
    }

    void ArrowInstantiate()
    {
        GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, arrowPrefab.transform.rotation);
        arrow.transform.forward = tower.position;
    }
}
