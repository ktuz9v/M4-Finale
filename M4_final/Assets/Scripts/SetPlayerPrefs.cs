using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPrefs : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetFloat("PlayerHealth", 100);
        PlayerPrefs.SetInt("Mp7Ammo", 90);
        PlayerPrefs.SetInt("M24Ammo", 24);
        PlayerPrefs.SetInt("Mp7", 45);
        PlayerPrefs.SetInt("M24", 8);
    }
}
