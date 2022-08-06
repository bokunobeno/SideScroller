using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _playr;
    
    private Transform _transform;
    private bool _detected = false;
    [SerializeField] private float _speed = 1f;
    private void Awake()
    {
        _transform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playr = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float _distance = Vector3.Distance(_playr.position, _transform.position);

        if (_distance <= 10 && _detected == false)
        {
            _detected = true;
        }

        if (_detected)
        {
            if (_playr.position.x < _transform.position.x)
            {
                transform.Translate(Vector3.right * -_speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }
        
    }
}
