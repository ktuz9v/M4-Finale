using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EndGameCamera;
    [SerializeField] NavMeshAgent Train;
    [SerializeField] GameObject FinalPoint;
    [SerializeField] GameObject Costil;
    private void OnTriggerEnter(Collider other)
    {
        EndGameCamera.SetActive(true);
        Player.SetActive(false);
        Train.SetDestination(FinalPoint.transform.position);
        Costil.SetActive(false);
        StartCoroutine(WaitForStop());
    }
    IEnumerator WaitForStop()
    {
        yield return new WaitForSeconds(5);
        Train.speed = 6;
        yield return new WaitForSeconds(5);
        Train.speed = 0;
    }
}
