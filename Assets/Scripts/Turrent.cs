using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bullet;
    private Transform _playr;
    private Transform _transform;
    private bool detected = false;

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
        transform.LookAt((_playr));
        DetectingPlayer();
    }

    void DetectingPlayer()
    {
        float distance = Vector3.Distance(_playr.position, _transform.position);
        if (distance <= 15 && !detected)
        {
            detected = true;
            StartCoroutine(Shooting());
        }
        else if(distance > 15)
        {
            detected = false;
           StopCoroutine(Shooting());
        }
    }
    
    
    IEnumerator Shooting()
    {
        while (detected)
        {
            yield return new WaitForSeconds(1);
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
