using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoEvent_ : MonoBehaviour
{
    public ZombieAI ZombieAI;
    public void GoEvent()
    {
        ZombieAI.IsStanding = true;
    }
    public void AttackDamage()
    {
        ZombieAI.AttackDamage();
    }
}
