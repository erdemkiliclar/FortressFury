using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10.0f; 
    public Transform target;
    private Rigidbody _rb;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Tower").transform;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Vector3 targetz = new Vector3(target.transform.position.x, target.transform.position.y + 1,
            target.transform.position.z);
        Vector3 targetDir = targetz - transform.position;
        _rb.velocity = targetDir.normalized * speed;
    }
}
