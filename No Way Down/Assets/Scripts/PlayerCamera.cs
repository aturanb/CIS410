using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform playerCameraLocation;

    void Update()
    {
        transform.position = playerCameraLocation.position;
    }
}
