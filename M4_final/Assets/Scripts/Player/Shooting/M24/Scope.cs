using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Camera Camera;
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Camera.fieldOfView = 15;
        }
        else
        {
            Camera.fieldOfView = 60;
        }
    }
}
