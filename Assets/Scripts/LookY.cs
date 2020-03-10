using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] float _mouseYSensitivity = -1f;
    
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        
        transform.localEulerAngles = new Vector3(
            transform.localEulerAngles.x + _mouseY * _mouseYSensitivity,
            transform.localEulerAngles.y,
            transform.localEulerAngles.z
        );
    }
}
