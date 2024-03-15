using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private TowerHealth _towerHealth;
    
    private void Awake()
    {
        _towerHealth = GameObject.FindGameObjectWithTag("Tower").GetComponent<TowerHealth>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            _towerHealth.towerHealth -= 5;
        }
        
    }
}
