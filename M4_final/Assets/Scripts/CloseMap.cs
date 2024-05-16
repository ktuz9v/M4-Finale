using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMap : MonoBehaviour
{
    [SerializeField] GameObject CloseMap_;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
            CloseMap_.SetActive(false);
    }

}