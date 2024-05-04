using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;
    public RectTransform ValueRectTransform;

    public GameObject GameplayUI;
    public GameObject GameOverUI;
    public GameObject Pause;
    public Mp7Shooting MP7;
    public M24Shooting M24;
    public Swap Swap;
    public CameraRotation CamRot;

    private float _maxValue;

    private void Start()
    {
        _maxValue = Health;
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(Health / _maxValue, 1);
    }

    public void DealDamageToPlayer(float Damage)
    {
        Health -= Damage;

        DrawHealthBar();
    }
    void Update()
    {
        if (Health <= 0)
        {
            GameOverUI.SetActive(true);
            GameplayUI.SetActive(false);
            Pause.SetActive(false);
            Time.timeScale = 0;
            Swap.enabled = false;
            MP7.enabled = false;
            M24.enabled = false;
            CamRot.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}