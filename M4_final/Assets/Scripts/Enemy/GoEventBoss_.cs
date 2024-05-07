using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoEventBoss_ : MonoBehaviour
{
    public BossZombieAI ZombieAI;
    public void AttackDamage()
    {
        ZombieAI.AttackDamage();
    }
}
