using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    private ParticleSystem stonePart;

    private void Start()
    {
        stonePart = GameObject.FindGameObjectWithTag("StonePart").GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            stonePart.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            stonePart.Play();
        }
    }
}
