using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
            player.DealDamageToPlayer(Damage);
        Destroy();
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
