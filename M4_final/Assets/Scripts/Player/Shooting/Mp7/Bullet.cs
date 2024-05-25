﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float Damage;
    private void Start()
    {
        Invoke("Destroy", 5);
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        var guard = other.gameObject.GetComponent<GuardHealth>();
        if (guard != null)
        {
            guard.TakeDamageGuard(Damage);
        }
        var zombie = other.gameObject.GetComponent<ZombieHealth>();
        if (zombie != null)
        {
            zombie.TakeDamageGuard(Damage);
        }
        Destroy();
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
