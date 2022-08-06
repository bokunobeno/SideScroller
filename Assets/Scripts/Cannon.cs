using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject bullet;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(bullet, spawnPoint.position, _transform.rotation);
        }
        
    }
}
