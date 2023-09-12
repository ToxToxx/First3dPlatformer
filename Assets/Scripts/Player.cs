using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float maxMovingSpeedCoef = 1.5f;


    private float maxMovingSpeed;
    private float minMovingSpeed = 5f;

    private bool isRunning;

    private bool isWalking;

    private bool isJumping;


    private Rigidbody rb;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameInput.OnShiftPressed += GameInput_OnShiftPressed;
        gameInput.OnSpacePressed += GameInput_OnSpacePressed;
        isRunning = false;
        isWalking = true;
        isJumping = false;
        maxMovingSpeed = moveSpeed * maxMovingSpeedCoef;
        minMovingSpeed = moveSpeed;

    }

    private void GameInput_OnSpacePressed(object sender, EventArgs e)
    {
        if (!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping=true;
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

    public bool SetWalking(bool parameter)
    {
        isWalking = parameter;
        return isWalking;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
        isWalking = moveDir != Vector3.zero;
        transform.position += moveSpeed * Time.deltaTime * moveDir;

    }

}
