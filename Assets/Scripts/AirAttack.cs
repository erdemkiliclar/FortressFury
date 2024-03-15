using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAttack : MonoBehaviour
{
    
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && ButtonManager.airStrike==true )
        {
            
            other.gameObject.GetComponent<Enemy>().TakeDamage(500);
            
        }
    }
}
