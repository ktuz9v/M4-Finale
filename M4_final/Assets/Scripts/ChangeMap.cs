using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    public PlayerHealth Player;
    public Mp7Shooting Mp7Shooting;
    public M24Shooting M24Shooting;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerHealth", Player.Health);
            PlayerPrefs.SetInt("Mp7Ammo", Mp7Shooting.AmmoInInventory);
            PlayerPrefs.SetInt("Mp7", Mp7Shooting.MagAmmo);
            PlayerPrefs.SetInt("M24Ammo", M24Shooting.AmmoInInventory);
            PlayerPrefs.SetInt("M24", M24Shooting.MagAmmo);
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }
}
