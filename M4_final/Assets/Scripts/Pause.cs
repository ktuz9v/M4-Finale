using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] CameraRotation CamRot;

    [SerializeField] GameObject _pausePanel;

    bool _isPaused = false;

    float _scaledTime;
    float _unscaledTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        CamRot.enabled = false;
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        CamRot.enabled = true;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        _isPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}