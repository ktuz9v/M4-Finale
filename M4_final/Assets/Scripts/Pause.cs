using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] CameraRotation CamRot;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _gameplayUI;

    bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        _isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        CamRot.enabled = false;
        _gameplayUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        _isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        CamRot.enabled = true;
        _gameplayUI.SetActive(true);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        _isPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}