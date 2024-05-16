using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnomaly : MonoBehaviour
{
    public float Forse;
    public float Damage;

    [SerializeField] AudioSource Audio;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (player != null && playerHealth != null)
        {
            player.GetComponent<PlayerController>().JumpAnomalyEffect(Forse);
            playerHealth.GetComponent<PlayerHealth>().DealDamageToPlayer(Damage);
            Audio.Play();
        }
    }
}
