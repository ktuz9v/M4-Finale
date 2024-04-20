using System;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraHolder;

    public float MinAngle;
    public float MaxAngle;

    public float RotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CamRotByY();
        CamRotByX();
    }
    private void CamRotByX()
    {
        float newAngleY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * RotationSpeed;
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);
    }
    private void CamRotByY()
    {
        float newAngleX = CameraHolder.localEulerAngles.x - Input.GetAxis("Mouse Y") * RotationSpeed;
        if (newAngleX > 180)
        {
            newAngleX -= 360;
        }

        newAngleX = Mathf.Clamp(newAngleX, MinAngle, MaxAngle);

        CameraHolder.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}