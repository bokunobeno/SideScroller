using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] Vector3 startingPoint;
    [SerializeField] Vector3 endingPoint;


    private void OnTriggerEnter(Collider other)
    {
        _transform.position = endingPoint;
    }

    private void OnTriggerExit(Collider other)
    {
        _transform.position = startingPoint;
    }
}
