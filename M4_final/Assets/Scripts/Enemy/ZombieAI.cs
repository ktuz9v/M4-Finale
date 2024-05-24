using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public float Damage;
    public NavMeshAgent Zombie;
    public Animator Animator;

    public Transform Player;
    public float Distanse;

    public CapsuleCollider Collider;

    public bool IsStanding = false;

    bool _isNotised;

    [SerializeField] AudioSource ZombieIdle;
    [SerializeField] AudioSource ZombieAttack;
    bool _isPlaying;
    void Update()
    {
        Notise();
        if (_isNotised && IsStanding)
        {
            Walk();
            Attack();
            Collider.enabled = true;
        }
    }
    public void AttackDamage()
    {
        if (Zombie.remainingDistance < 2)
            Player.GetComponent<PlayerHealth>().DealDamageToPlayer(Damage);
        _isPlaying = false;
    }
    private void Attack()
    {
        if (Zombie.remainingDistance < 2)
        {
            Animator.SetTrigger("Attack");
            if (_isPlaying == false)
            {
                _isPlaying = true;
                ZombieAttack.Play();
            }
        }
    }
    private void Walk()
    {
        Zombie.SetDestination(Player.position);
    }
    private void Notise()
    {
        if (Vector3.Distance(transform.position, Player.position) < Distanse && _isNotised == false)
        {
            Animator.SetTrigger("Awake");
            _isNotised = true;
            ZombieIdle.Play();
        }
    }
}
