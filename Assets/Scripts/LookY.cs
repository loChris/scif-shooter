using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] float _mouseYSensitivity = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
