using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPatrollingLogic : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
   
    

    private int targetPoint;
    


    void Start()
    {
        targetPoint = 0;
    }


    public void Patrolling(float moveSpeed)
    {

        if (transform.position == patrolPoints[targetPoint].position)
        {
            IncreaseTargetInt();
            
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, moveSpeed * Time.deltaTime);
    }

    public Vector3 GetTransformPosition()
    {
        return transform.position;
    }

    private void IncreaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    public int GetTargetPoint()
    {
        return targetPoint;
    }
}
