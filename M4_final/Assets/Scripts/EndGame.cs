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
    [SerializeField] GameObject THX;
    [SerializeField] GameObject THX1;
    [SerializeField] AudioSource Metro;
    private void OnTriggerEnter(Collider other)
    {
        EndGameCamera.SetActive(true);
        Player.SetActive(false);
        Train.SetDestination(FinalPoint.transform.position);
        Costil.SetActive(false);
        Metro.Stop();
        StartCoroutine(WaitForStop());
    }
    IEnumerator WaitForStop()
    {
        yield return new WaitForSeconds(5);
        Train.speed = 6;
        THX.SetActive(true);
        yield return new WaitForSeconds(5);
        Train.speed = 0;
        THX1.SetActive(true);
    }
}
