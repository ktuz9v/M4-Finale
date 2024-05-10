using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAdditionalMap : MonoBehaviour
{
    public GameObject AddMap;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
            AddMap.SetActive(true);
    }
}
