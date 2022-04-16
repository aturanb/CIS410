using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseRotation : MonoBehaviour
{
    [Header("Mouse Settings")]
    [SerializeField] Transform cameraHolder;
    [SerializeField] Transform playerOrientation;
    [SerializeField] float sensitivity = 1.80f;
    [SerializeField] float xRotationLimit = 90f;

    Vector2 rotation;

    void Start()
    {
        CursorLockHide();
    }

    void Update()
    {
        ProcessMouseInput();
        AdjustCameraRotation();
    }

    //Hides and locks the cursor
    void CursorLockHide() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Reads the mouse input and assigns it to rotation vector
    void ProcessMouseInput() 
    {
        rotation.x -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        rotation.y += Input.GetAxisRaw("Mouse X") * sensitivity;
    }

    //Uses rotation vector to change the rotation of the player
    void AdjustCameraRotation() 
    {
        
        cameraHolder.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
        playerOrientation.rotation = Quaternion.Euler(0, rotation.y, 0);
        //Limit the X-axis rotation
        rotation.x = Mathf.Clamp(rotation.x, -xRotationLimit, xRotationLimit);

    }
}
