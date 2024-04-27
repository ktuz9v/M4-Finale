using System;
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
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
