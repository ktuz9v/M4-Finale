using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp7Shooting : MonoBehaviour
{
    public int MagAmmo;
    public int AmmoInInventory; 

    public Bullet BulletPrefab;

    private float _shootinTimer;
    private float _fullReloadTimer;
    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Timers();
            Shooting();
            Reload();
        }
    }

    private void Reload()
    {
        if (MagAmmo < 1 && AmmoInInventory > 0 || Input.GetKeyDown(KeyCode.R) && AmmoInInventory > 0)
        {
            int MagLeftAmmo = 45 - MagAmmo;
            MagAmmo = 45;
            _fullReloadTimer = 0;
            AmmoInInventory -= MagLeftAmmo;
            if (AmmoInInventory < 0)
                MagAmmo += AmmoInInventory;
        }
    }
    private void Timers()
    {
        _shootinTimer += Time.deltaTime;
        _fullReloadTimer += Time.deltaTime;
    }
    private void Shooting()
    {
        if (Input.GetMouseButton(0) && _shootinTimer > 0.07f && MagAmmo > 0 && _fullReloadTimer > 1.3f)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            _shootinTimer = 0;
            MagAmmo--;
        }
    }


    public void PickUpAmmoMp7(int Ammo)
    {
        AmmoInInventory += Ammo;
    }
}
