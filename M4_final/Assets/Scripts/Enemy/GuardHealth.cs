using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    public float Health = 60;
    public void TakeDamageGuard(float Damage)
    {
        Health -= Damage;
    }
    void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
}
