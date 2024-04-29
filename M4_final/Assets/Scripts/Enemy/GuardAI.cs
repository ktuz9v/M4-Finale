using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public NavMeshAgent Navigation;
    public Animator Animator; 
    public List<Transform> PatrolPoints;
    public List<Transform> CoverPoints;

    public float FOV;
    public GameObject Player;

    public Bullet Bullet;
    public Transform Weapon;

    float _timeBetweenShots;
    float _reloadTimer;
    int _burstAmmo = 3;

    bool _isNotised;
    float _nextCoverPointTimer;
    void Update()
    {
        PlayerNotise();
        PatrolAttack();
        if (_isNotised == false)
            PatrolCalm();
        Attack(); 
        TimerUpdate();
        if (Navigation.isStopped)
            Animator.SetBool("IsWalking", false);
        else
            Animator.SetBool("IsWalking", true);
    }

    private void Attack()
    {
        Weapon.LookAt(Player.transform.position + Vector3.up);
        if (_isNotised)
        {
            if(_burstAmmo > 0 && _timeBetweenShots > 0.1 && _reloadTimer > 1.5)
            {
                Instantiate(Bullet, Weapon.position, Weapon.rotation);
                _burstAmmo--;
                _timeBetweenShots = 0;
            }
        }
        if (_burstAmmo <= 0)
        {
            _reloadTimer = 0;
            _burstAmmo = 3;
        }
    }
    private void TimerUpdate()
    {
        _nextCoverPointTimer += Time.deltaTime;
        _reloadTimer += Time.deltaTime;
        _timeBetweenShots += Time.deltaTime;
    }
    private void PatrolAttack()
    {
        if (_isNotised)
        {
            if (Navigation.remainingDistance < 2 && _nextCoverPointTimer > 8)
            {
                Navigation.destination = CoverPoints[Random.Range(0, PatrolPoints.Count)].position;
                _nextCoverPointTimer = 0;
            }
            transform.LookAt(Player.transform.position);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            if (_nextCoverPointTimer < 8 && Navigation.remainingDistance < 1)
                Navigation.isStopped = true;
            else
                Navigation.isStopped = false;
            Navigation.speed = 3.5f;
        }
    }
    private void PlayerNotise()
    {
        var direction = Player.transform.position - transform.position;
        _isNotised = false;

        if (Vector3.Angle(transform.forward, direction) < FOV)
        {
            RaycastHit Hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out Hit))
                if (Hit.collider.gameObject == Player.gameObject)
                {
                    _isNotised = true;
                }
        }
    }
    private void PatrolCalm()
    {
        if (!_isNotised)
        {
            if (Navigation.remainingDistance < 2 && !_isNotised)
            {
                Navigation.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
                Animator.SetBool("IsWalking", true);
            }
            Navigation.speed = 2;
        }
    }
}
