﻿using System.Collections;
using UnityEngine;
using TMPro;

public class M24Shooting : MonoBehaviour
{
    public int MagAmmo;
    public int AmmoInInventory;

    public Bullet BulletPrefab;

    public TextMeshProUGUI AmmoLeftInventory;
    public TextMeshProUGUI AmmoLeftInMag;

    private float _shootinTimer = 10;
    private float _fullReloadTimer = 10;

    [SerializeField] AudioSource Shot;
    [SerializeField] AudioSource ReloadSound;
    [SerializeField] AudioSource CaseBounse;
    private void Start()
    {
        AmmoInInventory = PlayerPrefs.GetInt("M24Ammo");
        MagAmmo = PlayerPrefs.GetInt("M24");
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Timers();
            Shooting();
            Reload();
        }
        AmmoLeftInventory.text = AmmoInInventory.ToString();
        AmmoLeftInMag.text = MagAmmo.ToString();
        if (AmmoInInventory <= 0)
        {
            AmmoInInventory = 0;
            AmmoLeftInventory.color = Color.red;
            AmmoLeftInventory.text = "0";
        }
        else
        {
            AmmoLeftInventory.color = Color.cyan;
        }
    }

    private void Reload()
    {
        if (MagAmmo < 1 && AmmoInInventory > 0 || Input.GetKeyDown(KeyCode.R) && AmmoInInventory > 0 && MagAmmo != 8)
        {
            int MagLeftAmmo = 8 - MagAmmo;
            MagAmmo = 8;
            _fullReloadTimer = 0;
            AmmoInInventory -= MagLeftAmmo;
            if (AmmoInInventory < 0)
                MagAmmo += AmmoInInventory;
            AmmoLeftInMag.text = MagAmmo.ToString();
            AmmoLeftInventory.text = AmmoInInventory.ToString();
            ReloadSound.Play();
        }
    }
    private void Timers()
    {
        _shootinTimer += Time.deltaTime;
        _fullReloadTimer += Time.deltaTime;
    }
    private void Shooting()
    {
        if (Input.GetMouseButton(0) && _shootinTimer > 1.7f && MagAmmo > 0 && _fullReloadTimer > 4f)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            _shootinTimer = 0;
            MagAmmo--;
            AmmoLeftInMag.text = MagAmmo.ToString();
            Shot.Play();
            StartCoroutine(CaseFalls());
        }
        if (MagAmmo < 3)
        {
            AmmoLeftInMag.color = Color.red;
        }
        else
        {
            AmmoLeftInMag.color = Color.cyan;
        }
    }
    IEnumerator CaseFalls()
    {
        yield return new WaitForSeconds(0.5f);
        CaseBounse.Play();
    }

    public void PickUpAmmoM24(int Ammo)
    {
        AmmoInInventory += Ammo;
        if (AmmoInInventory > 40)
            AmmoInInventory = 40;
    }
}
