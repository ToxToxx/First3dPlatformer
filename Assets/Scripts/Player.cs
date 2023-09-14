using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float rotatingSpeed = 60;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private float maxMovingSpeedCoef = 1.5f;
    [SerializeField] private float jetpackForceCoef = 100f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform playerVisual;
    [SerializeField] private float movementVectorY;
   

    private float maxMovingSpeed;
    private float minMovingSpeed = 5f;
    [SerializeField]private float maxFlyingTimer = 2f;
    [SerializeField]private float flyingTimer = 0;


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
            isJumping=true;
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
        JetpackLaunch();
        
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

    public void SetJetpackMaxTimer(float jetpackBuff)
    {       
        this.maxFlyingTimer += jetpackBuff;
    }
    public float GetJetpackMaxTimer( )
    {
        
        return maxFlyingTimer;
    }

    public bool SetWalking(bool parameter)
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
        if(moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotatingSpeed * Time.deltaTime);
        }
        

    }

    private void JetpackLaunch()
    {
        movementVectorY = GameInput.Instance.GetMovementVectorNormalized().y;
        if (movementVectorY >= 0.1 && !isFlying && flyingTimer <= 0.1 && !isOnEarth)
        {
            isFlying = true;
        }

        if (isFlying)
        {

            Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(0f, inputVector.y, 0f);
            transform.position += jetpackForceCoef * Time.deltaTime * moveDir;
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
