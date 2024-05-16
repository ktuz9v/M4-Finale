using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricAnomaly : MonoBehaviour
{
    public float Damage;
    public GameObject Anomaly;
    public GameObject Anomaly1;
    public GameObject Anomaly2;
    public GameObject Anomaly3;

    float _timer;

    [SerializeField] AudioSource Attack;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 2)
        {
            Anomaly.SetActive(true);
            Anomaly1.SetActive(true);
            Anomaly2.SetActive(true);
            Anomaly3.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_timer > 2)
        {
            var player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.DealDamageToPlayer(Damage);
                _timer = 0;
                Attack.Play();
            }
            Anomaly.SetActive(false);
            Anomaly1.SetActive(false);
            Anomaly2.SetActive(false);
            Anomaly3.SetActive(false);
        }
    }
}
