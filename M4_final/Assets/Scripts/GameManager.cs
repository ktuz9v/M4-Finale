using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit(); 
    }
    public void StartGameC1()
    {
        SceneManager.LoadScene("Chapter1 - Surfase");
    }
    public void StartGameC2()
    {
        SceneManager.LoadScene("Chapter2 - Bottom of the lab Map 1");
    }
}
