using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 15;

    [SerializeField] private float _lifeSpan = 5;

    private Rigidbody _rb;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _speed);
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.health_tracker--;
            Debug.Log(PlayerHealth.health_tracker);
            Destroy(gameObject);
        }
    }
    IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(_lifeSpan);
        Destroy(gameObject);
    }
 
}
