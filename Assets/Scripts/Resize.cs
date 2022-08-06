using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private Vector3 _transformLocalScale;
    [SerializeField] private float endScale;
    // Start is called before the first frame update
    void Awake()
    {
        _transform = this.transform;
        _transformLocalScale = _transform.localScale;
        enabled = false;
    }

    private void FixedUpdate()
    {
        _transformLocalScale.y = endScale;
        _transform.localScale = _transformLocalScale;
    }

}
