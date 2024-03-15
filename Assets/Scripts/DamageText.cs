using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private Bullet _bullet;
    [SerializeField] private GameObject _canvas;

    private void Awake()
    {
        _bullet = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Bullet>();

    }

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "" + _bullet.damage;
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(_canvas);
    }
}
