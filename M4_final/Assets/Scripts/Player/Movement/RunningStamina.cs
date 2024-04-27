using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningStamina : MonoBehaviour
{
    public PlayerController Controller;
    public RectTransform StaminaBar;

    float _staminaLeft = 3;
    float _stamina;
    void Start()
    {
        _stamina = _staminaLeft;
    }
    void Update()
    {
        _staminaLeft = Controller.RunningTimer;
        StaminaBar.anchorMax = new Vector2(_staminaLeft / _stamina, 1);
    }
}
