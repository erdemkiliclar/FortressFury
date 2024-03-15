using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemCount : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _gemText;
    public float gemCount;

    private void Start()
    {
        gemCount = PlayerPrefs.GetFloat("GemCount", gemCount);
    }

    // Update is called once per frame
    void Update()
    {
        _gemText.text = " " + gemCount;
    }
}
