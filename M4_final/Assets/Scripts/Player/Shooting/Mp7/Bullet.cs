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
        Destroy(gameObject);
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.DealDamageToPlayer(Damage);
        }
        var guard = other.GetComponent<GuardHealth>();
        if (guard != null)
            guard.TakeDamageGuard(Damage);
        var zombie = other.GetComponent<ZombieHealth>();
        if (zombie != null)
            zombie.TakeDamageGuard(Damage);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
