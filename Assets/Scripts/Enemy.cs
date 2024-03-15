using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image healtBarSprite;
    public GameObject healtbar;
    public float speed = 10f;  
    public float health = 100f;
    float MaxHealt;
    public Transform target;
    private GameObject _player;
    private GameObject tower;
    private Rigidbody _rb;
    public bool _isdead;
    Camera cam;
    public GameObject gem;
    private void Awake()
    {
        _isdead = false;
        tower=GameObject.FindGameObjectWithTag("Tower");
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        target = tower.transform;
    }

    private void Start()
    {
        this.gameObject.transform.LookAt(_player.transform.position);
        MaxHealt = health;
        cam = Camera.main;

    }

    private void FixedUpdate()
    {
        Vector3 targetDir = target.position - transform.position;
        _rb.velocity = targetDir.normalized * speed;
        transform.rotation = Quaternion.LookRotation(targetDir);
    }

    private void Update()
    {
        healtbar.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        
        UpdateHealtBar();

        if (health <= 0f)
        {
            
            Die();
        }
    }

    public void Die()
    {
        Instantiate(gem, new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z), gem.transform.rotation);
        _isdead = true;
        speed = 0;
        GetComponent<Animator>().SetBool("isDie",true);
        GetComponent<BoxCollider>().enabled = false;
        gameObject.tag = "Untagged";
        
        tower.GetComponent<Tower>().nearestEnemy = null;
        StartCoroutine(WaitDestroy());
        
    }
    
    public void UpdateHealtBar()
    {
        healtBarSprite.fillAmount = health/MaxHealt;
    }
    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            GetComponent<Animator>().SetBool("isAttack",true);
            speed = 0;
        }
    }
}
