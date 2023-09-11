using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private GameInput gameInput; 

    private Rigidbody rb;


    private bool isWalking;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameInput.OnSpacePressed += GameInput_OnSpacePressed;
        isWalking = true;
    }

    private void GameInput_OnSpacePressed(object sender, EventArgs e)
    {
        if (isWalking)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isWalking = false;
        }         
    }

    private void Update()
    {
      
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
        transform.position += moveDir * moveSpeed * Time.deltaTime;


        float rotateSpeed = 10f;
        transform.up = Vector3.Slerp(transform.up, moveDir, Time.deltaTime * rotateSpeed);
    
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    private void OnCollisionEnter(Collision collision)
    {
        isWalking = true;
    }

}
