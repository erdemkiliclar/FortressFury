using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public Image healtBarSprite;
    public GameObject healtbar;
    Camera cam;
    float MaxHealt;
    public static bool gameOver;

    private CameraShake _cameraShake;
    public float towerHealth = 100;
    [SerializeField] private Animator _towerAnim;

    private void Awake()
    {
        gameOver = false;
        _cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    private void Start()
    {
        MaxHealt = towerHealth;
        cam = Camera.main;
    }
    private void Update()
    {
        healtbar.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        if (towerHealth<=0)
        {
            
            _towerAnim.Play("tower");
            _cameraShake.Shake();
            DestroyEnemy();
        }

        UpdateHealtBar();
    }
    public void UpdateHealtBar()
    {
        healtBarSprite.fillAmount = towerHealth / MaxHealt;
    }

    void DestroyEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var obj in enemies)
        {
            Destroy(obj);
        }
    }
}
