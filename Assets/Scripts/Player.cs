using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float maxMovingSpeedCoef = 1.5f;


    private float maxMovingSpeed;
    private float minMovingSpeed = 5f;

    private bool isRunning;

    private bool isWalking;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameInput.OnShiftPressed += GameInput_OnShiftPressed;
        gameInput.OnSpacePressed += GameInput_OnSpacePressed;
        isRunning = false;
        isWalking = true;
        maxMovingSpeed = moveSpeed * maxMovingSpeedCoef;
        minMovingSpeed = moveSpeed;

    }

    private void GameInput_OnSpacePressed(object sender, EventArgs e)
    {
        if (isWalking)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isWalking = false;
        }
    }

    private void GameInput_OnShiftPressed(object sender, EventArgs e)
    {
        
        if (!isRunning)
        {
            moveSpeed = maxMovingSpeed;
            isRunning = true;
        }
        else
        {
            moveSpeed = minMovingSpeed;
            isRunning = false;                   
        }
       
    }

    private void Update()
    {
        HandleMovement();
        
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isWalking = true;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

    }

}
