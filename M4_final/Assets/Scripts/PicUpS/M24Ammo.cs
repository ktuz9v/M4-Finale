using UnityEngine;

public class M24Ammo : MonoBehaviour
{
    public int Ammo;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.GetComponentInChildren<M24Shooting>().PickUpAmmoM24(Ammo);
        }
        Destroy(gameObject);
    }
}
