using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] Transform spawn_point;
    public static int health_tracker;
    private Transform _transform;
    private IEnumerator damage_coroutine;
    private bool isDamaged = false;
    private Material mat_player;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

    private void Awake()
    {
        _transform = transform;
        health_tracker = health;
        mat_player = GetComponent<Renderer> ().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (health_tracker <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _transform.position = spawn_point.position;
        health_tracker = health;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isDamaged == false)
        {
            isDamaged = true;
            mat_player.SetColor(EmissionColor, new Color(191, 5, 39, 0.1f) * 1/60);
            damage_coroutine = Damage();
            StartCoroutine(damage_coroutine);
        }
    }


    IEnumerator Damage()
    {
        health_tracker--;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        mat_player.SetColor(EmissionColor, new Color(74, 0, 191, 0.1f) * 1/60);
    }
}
