using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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



    [SerializeField] Sprite _soundOnSprite;
    [SerializeField] Sprite _soundOffSprite;

    [SerializeField] Button _soundButton;

    public void SoundToggleButton()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            _soundButton.image.sprite = _soundOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            _soundButton.image.sprite = _soundOffSprite;
        }
    }
}