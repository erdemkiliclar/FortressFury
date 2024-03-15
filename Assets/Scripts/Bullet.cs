using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // Speed of the bullet
    public float damage = 10f;  // Damage the bullet does

    private Transform target;  // Target the bullet is seeking
    private ParticleSystem hitPart;
    [SerializeField] private GameObject _damageText;
    
    private void Start()
    {
        hitPart = GameObject.FindGameObjectWithTag("HitPart").GetComponent<ParticleSystem>();
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    
    
    private void HitTarget()
    {
        
        hitPart.transform.position = this.gameObject.transform.position; 
        Instantiate(_damageText, transform.position, _damageText.transform.rotation);
        hitPart.Play();
        Destroy(gameObject);
    
        Enemy enemy = target.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    
}
