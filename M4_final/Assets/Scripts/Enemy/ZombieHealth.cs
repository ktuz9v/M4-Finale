using UnityEngine;
using UnityEngine.AI;

public class ZombieHealth : MonoBehaviour
{
    public float Health = 60;
    public Animator Animator;
    public ZombieAI Zombie;
    public CapsuleCollider Capsule;
    public NavMeshAgent Navigation;

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
            Zombie.enabled = false;
            Capsule.enabled = false;
            Navigation.speed = 0;
            _isDead = true;
        }
        if (_isDead == true)
        {
            _timeBeforeCorpseDisappear += Time.deltaTime;
        }
        if (_timeBeforeCorpseDisappear > 30)
        {
            Destroy(gameObject);
        }
    }
}
