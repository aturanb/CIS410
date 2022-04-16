using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    [Header("Player")]
    [SerializeField] Transform playerOrientation;

    [Header("Ground Movement")]
    [SerializeField] float walkingSpeed = 30f;
    [Tooltip("When shift gets pressed, Walking Speed gets multiplied with Sprint Multiplier")]
    [SerializeField] float sprintMultiplier = 1.5f;
    [SerializeField] float dragOnGround = 6f;
    
    [Header("Air Movement")]
    [Tooltip("Amount of jumps that can be done after leaving the ground")]
    [SerializeField] int totalJumpAmount = 2;
    [SerializeField] float speedOnAir = 2f;
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] float dragOnAir = 2f;


    
    //To keep track of the jumps left that player can do
    private int jumpsLeft;

    private float currentGroundSpeed;

    //Variables to store horizontal and vertical movement inputs
    float horizontal;
    float vertical;

    //For checking if the player is on the ground
    bool onGround;

    //For calculating the Vector3 movement of the player
    Vector3 m_Movement;
    
    Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        jumpsLeft = totalJumpAmount;
        currentGroundSpeed = walkingSpeed;
    }

    private void Update()
    {
        DragControl();
        SetGroundSpeed();
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft!=0)
            Jump();


    }

    //Check if the player is sprinting or walking, then set the currentGroundSpeed
    private void SetGroundSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && onGround)
            currentGroundSpeed = walkingSpeed * sprintMultiplier;
        else
            currentGroundSpeed = walkingSpeed;
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
        else
            m_Rigidbody.AddForce(m_Movement.normalized * speedOnAir, ForceMode.Acceleration);
    }

    //For detecting collisions and resetting variables
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
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
