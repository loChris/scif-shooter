using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] float _mouseXSensitivity = 1f;

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(
            transform.localEulerAngles.x,
            transform.localEulerAngles.y + _mouseX * _mouseXSensitivity,
            transform.localEulerAngles.z
            );
    }
}
