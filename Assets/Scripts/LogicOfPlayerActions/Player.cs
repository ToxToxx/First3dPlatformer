using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public event EventHandler OnPlayerDestroyed;

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float rotatingSpeed = 60;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private float maxMovingSpeedCoef = 1.5f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform playerVisual;


    private float maxMovingSpeed;
    private float minMovingSpeed = 5f;


    private bool isRunning;
    [SerializeField] private bool isFlying;


    private bool isWalking;
    private bool isJumping;
    private bool isOnEarth;


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
        isJumping = false;
        isFlying = false;
        isWalking = true;
        isOnEarth = false;

        maxMovingSpeed = moveSpeed * maxMovingSpeedCoef;
        minMovingSpeed = moveSpeed;


    }

    private void GameInput_OnSpacePressed(object sender, EventArgs e)
    {
        if (!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            isOnEarth = false;
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

    public bool GetIsWalking()
    {
        return isWalking;
    }
    public bool GetIsFlying()
    {
        return isFlying;
    }
    public bool GetIsJumping()
    {
        return isJumping;
    }

    public bool GetIsOnEarth()
    {
        return isOnEarth;
    }

    public bool SetWalking(bool parameter)
    {
        isWalking = parameter;
        return isWalking;
    }
    public bool SetIsFlying(bool parameter)
    {
        isWalking = parameter;
        return isWalking;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        isOnEarth = true;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new(inputVector.x, 0f, 0f);
        isWalking = moveDir != Vector3.zero;

        transform.position += moveSpeed * Time.deltaTime * moveDir;
        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotatingSpeed * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        OnPlayerDestroyed?.Invoke(this, EventArgs.Empty);
    }
}
