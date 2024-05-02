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

    public bool IsStanding = false;

    bool _isNotised;
    void Update()
    {
        Notise();
        if (_isNotised && IsStanding)
        {
            Walk();
            Attack();
        }
    }
    public void AttackDamage()
    {
        Player.GetComponent<PlayerHealth>().DealDamageToPlayer(Damage);
    }
    private void Attack()
    {
        if (Zombie.remainingDistance < 2)
            Animator.SetTrigger("Attack");
    }
    private void Walk()
    {
        Zombie.SetDestination(Player.position);
    }
    private void Notise()
    {
        if (Vector3.Distance(transform.position, Player.position) < Distanse)
        {
            Animator.SetTrigger("Awake");
            _isNotised = true;
        }
    }
}
