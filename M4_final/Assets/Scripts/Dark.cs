using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : MonoBehaviour
{
    [SerializeField] PlayerHealth PH;
    [SerializeField] GameObject Message;
    float _timeLeft;
    bool _isInDark;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            _isInDark = true;
            Message.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            _isInDark = false;
            Message.SetActive(false);
            _timeLeft = 0;
        }
    }
    void Update()
    {
        if (_isInDark)
            _timeLeft += Time.deltaTime;
        if (_timeLeft > 5)
            PH.DealDamageToPlayer(10000);
    }
}
