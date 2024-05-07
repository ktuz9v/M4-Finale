using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossZombieAI : MonoBehaviour
{
    public float Damage;
    public NavMeshAgent Zombie;
    public Animator Animator;

    public Transform Player;
    public float Distanse;

    bool _isNotised;
    void Update()
    {
        Notise();
        Walk();
        if (_isNotised)
            Attack();
    }
    public void AttackDamage()
    {
        if (Zombie.remainingDistance < Zombie.stoppingDistance)
            Player.GetComponent<PlayerHealth>().DealDamageToPlayer(Damage);
    }
    private void Attack()
    {
        if (Zombie.remainingDistance < Zombie.stoppingDistance)
            Animator.SetTrigger("Attack");
    }
    private void Walk()
    {
        Zombie.SetDestination(Player.position);
    }
    private void Notise()
    {
        _isNotised = false;

        var direction = Player.transform.position - transform.position;
        RaycastHit Hit;
        if (Physics.Raycast(transform.position + Vector3.up, direction, out Hit))
            if (Hit.collider.gameObject == Player.gameObject)
            {
                _isNotised = true;
            }
    }
}
