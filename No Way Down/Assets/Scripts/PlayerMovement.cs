using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    [Header("Player")]
    [SerializeField] Transform playerOrientation;
    [SerializeField] Transform playerCameraLocation;
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject glider;
    [SerializeField] GameObject handWithWeapon;

    [Header("Camera Effects")]
    [SerializeField] private float slidingCameraHeight;
    [SerializeField] private float fov;
    [SerializeField] private float slidingFov;
    [SerializeField] private float glidingFov;
    [SerializeField] private float fovTransitionTime;

    [Header("Ground Movement")]
    [SerializeField] float walkingSpeed = 30f;
    [SerializeField] float slidingSpeed = 55f;
    //[SerializeField] float slidingAcceleration = 20f;
    [Tooltip("When shift gets pressed, Walking Speed gets multiplied with Sprint Multiplier")]
    [SerializeField] float sprintSpeed = 45f;
    [SerializeField] float sprintAcceleration = 1.5f;
    [SerializeField] float dragOnGround = 6f;
    
    [Header("Air Movement")]
    [Tooltip("Amount of jumps that can be done after leaving the ground")]
    [SerializeField] int totalJumpAmount = 2;
    [SerializeField] float speedOnAir = 2f;
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] float dragOnAir = 2f;

    [Header("Air Gliding Movement")]
    
    [SerializeField] float glidingDownwardForce = 2f;
    [SerializeField] float glidingDuration = 4f;
    float counter = 0f;




    //To keep track of the jumps left that player can do
    private int jumpsLeft;

    private float currentGroundSpeed;

    //Variables to store horizontal and vertical movement inputs
    float horizontal;
    float vertical;

    //For checking if the player is on the ground
    bool onGround;
    bool gliding;

    //For calculating the Vector3 movement of the player
    Vector3 m_Movement;
    
    public Rigidbody m_Rigidbody;
    

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        jumpsLeft = totalJumpAmount;
        currentGroundSpeed = walkingSpeed;
        gliding = false;
        glider.SetActive(false);
    }

    private void Update()
    {
        DragControl();
        SetGroundSpeed();
        Gliding();
        //Sliding(); INPROGRESS
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft!=0)
            Jump();

    }

    private void Gliding()
    {
        
        if (!onGround && Input.GetKey(KeyCode.F) && counter < glidingDuration)
        {
            handWithWeapon.SetActive(false);
            glider.SetActive(true);
            counter += Time.deltaTime;
            Debug.Log(counter);
            jumpsLeft = 0;
            m_Rigidbody.useGravity = false;
            gliding = true;
            m_Rigidbody.AddForce(Vector3.down * glidingDownwardForce, ForceMode.Force);
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, glidingFov, fovTransitionTime * Time.deltaTime);
        }
        else
        {
            m_Rigidbody.useGravity = true;
            glider.SetActive(false);
            handWithWeapon.SetActive(true);
            gliding = false;
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, fov, fovTransitionTime * Time.deltaTime);
        }

    }

    //INPROGRESS (NOT ENABLED)
    private void Sliding()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W) && onGround)
        {
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, slidingFov, fovTransitionTime * Time.deltaTime);
            m_Rigidbody.AddForce(playerOrientation.forward * slidingSpeed, ForceMode.VelocityChange);
            //currentGroundSpeed = Mathf.Lerp(currentGroundSpeed, slidingSpeed, slidingAcceleration * Time.deltaTime);


        }
        
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, fov, fovTransitionTime * Time.deltaTime);

    }


    //Check if the player is sprinting or walking, then set the currentGroundSpeed
    void SetGroundSpeed()
    {

        if (Input.GetKey(KeyCode.LeftShift) && onGround)
        {
            currentGroundSpeed = Mathf.Lerp(currentGroundSpeed, sprintSpeed, sprintAcceleration * Time.deltaTime);
        }
        else
            currentGroundSpeed = Mathf.Lerp(currentGroundSpeed, walkingSpeed, sprintAcceleration * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        ProccessMovementInput();
        Move();  
    }

    //Read the Horizontal and Vertical Inputs and calculate the vector3 movement direction
    private void ProccessMovementInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        m_Movement = playerOrientation.forward * vertical + playerOrientation.right * horizontal;
    }

    //Move the player accordingly it's position on ground or air
    void Move() {
        if (onGround)
            m_Rigidbody.AddForce(m_Movement.normalized * currentGroundSpeed, ForceMode.Acceleration);
        else if(!onGround && !gliding)
            m_Rigidbody.AddForce(m_Movement.normalized * speedOnAir, ForceMode.Acceleration);
    }

    //For detecting collisions and resetting variables
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "spawnGround1" || other.gameObject.tag == "spawnGround2")
        {
            counter = 0;
            onGround = true;
            jumpsLeft = totalJumpAmount;
        }
        else if (other.gameObject.tag == "jumppad")
        {
            onGround = false;
            m_Rigidbody.AddForce(transform.up * jumpImpulse * 10, ForceMode.Impulse);
            jumpsLeft = totalJumpAmount;
        }
    }

    private void Jump()
    {
        onGround = false;
        m_Rigidbody.AddForce(transform.up * jumpImpulse, ForceMode.Impulse);
        jumpsLeft--;
    }

    void DragControl() 
    {
        if(onGround)
            m_Rigidbody.drag = dragOnGround;
        else
            m_Rigidbody.drag = dragOnAir;
    }


}
