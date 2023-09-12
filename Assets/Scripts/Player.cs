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
    [SerializeField] private float JetpackForceCoef = 100f;


    private float maxMovingSpeed;
    private float minMovingSpeed = 5f;
    private float maxFlyingTimer = 2f;
    [SerializeField]private float flyingTimer = 0;


    private bool isRunning;
   [SerializeField] private bool isFlying;
    

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
        isFlying = false;
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

    public void BouncePlayer(float playerBounceCoef)
    {
        rb.AddForce(Vector3.up * playerBounceCoef, ForceMode.Impulse);
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
        JetpackLaunch();


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
        Vector3 moveDir = new Vector3(inputVector.x, 0f, 0f);
        isWalking = moveDir != Vector3.zero;
        transform.position += moveSpeed * Time.deltaTime * moveDir;

    }

    private void JetpackLaunch()
    {
        if (!isFlying && flyingTimer <= 0.5 && isJumping)
        {
            isFlying = true;
            
        }
        else if (isFlying)
        {

            Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(0f, inputVector.y, 0f);
            transform.position += JetpackForceCoef * Time.deltaTime * moveDir;
            flyingTimer += Time.deltaTime;
            if (flyingTimer > maxFlyingTimer)
            {
                isFlying = false;
            }
            
        } else if (!isFlying)
        {
            if(flyingTimer > 0)
            {
                flyingTimer -= Time.deltaTime;
            }
            else
            {
                flyingTimer = 0;
            }
            
        }
        
    }

}
