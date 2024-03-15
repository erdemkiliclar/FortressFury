using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private ParticleSystem _gemPart;
    private GemCount _gemCount;

    private void Awake()
    {
        _gemCount = GameObject.FindGameObjectWithTag("Main").GetComponent<GemCount>();
        _gemPart = GameObject.FindGameObjectWithTag("GemPart").GetComponent<ParticleSystem>();
        
    }

    private void Start()
    {
        StartCoroutine(WaitforDestroy());
        
    }


    IEnumerator WaitforDestroy()
    {
        yield return new WaitForSeconds(1);
        _gemPart.transform.position = this.transform.position;
        _gemCount.gemCount += 10;
        PlayerPrefs.SetFloat("GemCount",_gemCount.gemCount);
        _gemPart.Play();
        Destroy(this.gameObject);

    }
    
}
