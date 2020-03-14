using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _gravity = 9.81f;
    
    // Start is called before the first frame update
    void Start()
    {
        GetGameComponents();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        //if left click, cast ray from center point of main camera
        if (Input.GetMouseButton(0))
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(
                new Vector3(
                    0.5f, 
                    0.5f, 
                    0
                    )
                );
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("raycast hit" + hitInfo.transform.name);
            }
        }
    }

    void GetGameComponents()
    {
        _controller = GetComponent<CharacterController>();
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        
        _controller.Move(velocity * Time.deltaTime);
    }
}
