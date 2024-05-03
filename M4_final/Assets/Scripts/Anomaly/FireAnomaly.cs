using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireAnomaly : MonoBehaviour
{
    public float Damage;
    public GameObject Player;
    public GameObject FireMessage;
    public Image BurnImage;

    bool _isBurning;
    bool _isActive;
    void Update()
    {   
        if (_isActive)
            Player.GetComponent<PlayerHealth>().DealDamageToPlayer(Damage * Time.deltaTime);
        if (_isBurning)
        {
            Color color = BurnImage.color;
            color.a += 0.8f * Time.deltaTime;
            BurnImage.color = color;
            if (BurnImage.color.a > 0.5)
                color.a = 0.5f;
            BurnImage.color = color;
        }
        if (!_isBurning)
        {
            Color color = BurnImage.color;
            color.a -= 0.3f * Time.deltaTime;
            if (color.a < 0)
                color.a = 0;
            BurnImage.color = color;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            _isActive = true;
            FireMessage.SetActive(true);
            _isBurning = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            _isActive = false;
            FireMessage.SetActive(false);
            _isBurning = false;
        }
    }
}
