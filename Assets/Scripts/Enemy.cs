using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObjectPatrollingLogic gameObjectPatrollinglogic;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotatingSpeed = 60;
    private int currentPoint;

    private void Start()
    {
        currentPoint = -1;
    }

    private void Update()
    {
        gameObjectPatrollinglogic.Patrolling(moveSpeed);
        
        if(gameObjectPatrollinglogic.GetTargetPoint() != currentPoint)
        {
            RotateEnemy();
            currentPoint = gameObjectPatrollinglogic.GetTargetPoint();
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
           Destroy(collision.gameObject);
        }
    }
    private void RotateEnemy()
    {
        
        Vector3 moveDir = gameObjectPatrollinglogic.transform.position;

        if (moveDir != Vector3.zero)
        {

            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotatingSpeed * Time.deltaTime);
        }

    }
}
