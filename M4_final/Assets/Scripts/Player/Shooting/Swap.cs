using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public Camera Camera;

    public GameObject Mp7;
    public Mp7Shooting Mp7Shooting;

    public GameObject M24;
    public M24Shooting M24Shooting;
    public Scope Scope;

    [SerializeField] AudioSource SwapAudio;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapAudio.Play();
            Mp7.SetActive(false);
            Mp7Shooting.enabled = false;
            M24.SetActive(true);
            M24Shooting.enabled = true;
            Scope.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapAudio.Play();
            Camera.fieldOfView = 60;

            M24.SetActive(false);
            M24Shooting.enabled = false;
            Scope.enabled = false;
            Mp7.SetActive(true);
            Mp7Shooting.enabled = true;
        }
    }
}
