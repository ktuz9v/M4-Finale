using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentTrigger : MonoBehaviour
{
    [SerializeField] BossZombieAI AI;
    private void OnTriggerEnter(Collider other)
    {
        AI.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        AI.enabled = true;
    }
}
