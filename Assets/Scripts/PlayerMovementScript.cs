using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float mouseSensitivity = 2f; 
    public Transform playerBody;  

    private float xRotation = 0f;  

    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerMovement();

        CameraMovement();
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");  

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);  
    }
}
