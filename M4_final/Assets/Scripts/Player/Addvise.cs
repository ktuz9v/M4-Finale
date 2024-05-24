using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addvise : MonoBehaviour
{
    [SerializeField] GameObject AddviseBackGround;
    [SerializeField] GameObject AddviseText;
    bool _alreadyUsed;
    void OnTriggerEnter (Collider other)
    {
        var playr = other.GetComponent<PlayerHealth>();
        if (playr != null && !_alreadyUsed)
        {
            AddviseBackGround.SetActive(true);
            AddviseText.SetActive(true);
            StartCoroutine(TimeForDisappear());
            _alreadyUsed = true;
        }
    }

    IEnumerator TimeForDisappear()
    {
        yield return new WaitForSeconds(5);
        AddviseBackGround.SetActive(false);
        AddviseText.SetActive(false);
    }
}
