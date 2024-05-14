using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardHealth : MonoBehaviour
{
    public float Health = 60;
    public Animator Animator;
    public GuardAI Guard;
    public CapsuleCollider Capsule;
    public NavMeshAgent Navigation;
    public GameObject Mp7;

    [SerializeField] AudioSource Walk;

    bool _isDead;
    float _timeBeforeCorpseDisappear;
    public void TakeDamageGuard(float Damage)
    {
        Health -= Damage;
    }
    void Update()
    {
        if (Health <= 0)
        {
            Animator.SetBool("IsDead", true);
            Guard.enabled = false;
            Capsule.enabled = false;
            Navigation.speed = 0;
            _isDead = true;
            Destroy(Mp7);
            Walk.Stop();
        }
        if (_isDead == true)
        {
            _timeBeforeCorpseDisappear += Time.deltaTime;
        }
        if (_timeBeforeCorpseDisappear > 15)
        {
            Destroy(gameObject);
        }
    }
}
