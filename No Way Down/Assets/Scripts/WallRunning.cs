using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    [SerializeField] Transform orientation;
    [Header("Wall Detection")]
    [SerializeField] float wallDistance = 0.5f;
    [SerializeField] float minJumpHeight = 1.5f;

    [Header("Forces")]
    [SerializeField] float wallRunningDownwardForce = 1.5f;
    [SerializeField] float wallRunningJumpForce = 1.5f;
    [SerializeField] float jumpForceMultiplier = 80f;

    [Header("Camera Effects")]
    [SerializeField] Camera playerCamera;
    [SerializeField] float fov;
    [SerializeField] float runningFov;
    [SerializeField] float fovTransitionTime;
    [SerializeField] float cameraTilt;
    [SerializeField] float cameraTiltTransitionTime;

    public float tilt { get; private set; }




    bool wallLeft = false;
    bool wallRight = false;

    Rigidbody m_rigidbody;
    RaycastHit leftWallHit;
    RaycastHit rightWallHit;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IsThereWall();
        if (AbleToWallRun())
        {
            if (wallLeft)
            {
                StartWallRunning();
            }
            else if (wallRight)
            {
                StartWallRunning();
            }
            else
            {
                StopWallRunning();
            }
        }
        else {
            StopWallRunning();
        }
    }
    
    void IsThereWall()
    {
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallDistance);
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallDistance);

    }

    bool AbleToWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight);  
    }

    void StartWallRunning() 
    {
        m_rigidbody.useGravity = false;
        m_rigidbody.AddForce(Vector3.down * wallRunningDownwardForce, ForceMode.Force);

        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, runningFov, fovTransitionTime * Time.deltaTime);

        if (wallLeft)
            tilt = Mathf.Lerp(tilt, -cameraTilt, cameraTiltTransitionTime * Time.deltaTime);

        else if (wallRight)
            tilt = Mathf.Lerp(tilt, cameraTilt, cameraTiltTransitionTime * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (wallLeft)
            {
                Vector3 jumpDir = transform.up + leftWallHit.normal;
                m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, 0, m_rigidbody.velocity.z);
                m_rigidbody.AddForce(jumpDir * wallRunningJumpForce * jumpForceMultiplier, ForceMode.Force);
            }
            else if (wallRight)
            {
                Vector3 jumpDir = transform.up + rightWallHit.normal;
                m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, 0, m_rigidbody.velocity.z);
                m_rigidbody.AddForce(jumpDir * wallRunningJumpForce * jumpForceMultiplier, ForceMode.Force);
            }
        }


    }

    void StopWallRunning()
    {
        m_rigidbody.useGravity = true;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, fov, fovTransitionTime * Time.deltaTime);
        
        tilt = Mathf.Lerp(tilt, 0, cameraTiltTransitionTime * Time.deltaTime);
    }
}
