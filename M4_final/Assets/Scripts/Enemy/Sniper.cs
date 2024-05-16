using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject Player;
    public Bullet Bullet;

    [SerializeField] AudioSource Shot;

    float _timeForShot;
    float _reload;
    bool _isNotised;
    void Update()
    {
        Notise();
        TimerUpdate();
        Attack();
    }

    private void Attack()
    {
        if (_isNotised)
        {
            transform.LookAt(Player.transform.position + Vector3.up);
            if (_timeForShot > 1 && _reload > 4)
            {
                Instantiate(Bullet, transform.position, transform.rotation);
                _reload = 0;
            }
        }
    }
    private void TimerUpdate()
    {
        _reload += Time.deltaTime;
        if (_isNotised)
            _timeForShot += Time.deltaTime;
        else
            _timeForShot = 0;
    }
    private void Notise()
    {
        var direction = Player.transform.position - transform.position;
        _isNotised = false;
        
        RaycastHit Hit;
        if (Physics.Raycast(transform.position + Vector3.up, direction, out Hit))
            if (Hit.collider.gameObject == Player.gameObject)
            {
                _isNotised = true;
            }
    }
}
