using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem airPart, healPart, bufPart, flashPart;
    private TowerHealth _towerHealth;
    private GemCount _gemCount;
    public static bool airStrike = false;

    private void Awake()
    {
        _towerHealth = GameObject.FindGameObjectWithTag("Tower").GetComponent<TowerHealth>();
        _gemCount = GameObject.FindGameObjectWithTag("Main").GetComponent<GemCount>();
    }


    public void AirStrike()
    {
        airStrike = true;
        flashPart.Play();
        _gemCount.gemCount -= 50;
        PlayerPrefs.SetFloat("GemCount",_gemCount.gemCount);
        StartCoroutine(FlashPart());
    }

    public void HealPart()
    {
        healPart.Play();
        _towerHealth.towerHealth += 20;
        _gemCount.gemCount -= 50;
        PlayerPrefs.SetFloat("GemCount",_gemCount.gemCount);

    }

    public void BufPart()
    {
        bufPart.Play();
        _gemCount.gemCount -= 50;
        PlayerPrefs.SetFloat("GemCount",_gemCount.gemCount);
    }

    IEnumerator FlashPart()
    {
        yield return new WaitForSeconds(0.5f);
        airPart.Play();
        yield return new WaitForSeconds(1f);
        flashPart.Play();
        yield return new WaitForSeconds(1f);
        airStrike = false;
    }
}
