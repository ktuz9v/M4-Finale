using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp7Ammo : MonoBehaviour
{
    public int Ammo;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.GetComponentInChildren<Mp7Shooting>().PickUpAmmoMp7(Ammo);
        }
        Destroy(gameObject);
    }
}
