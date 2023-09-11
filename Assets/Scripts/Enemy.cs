using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private int targetPoint;
    [SerializeField] private float moveSpeed = 10f;


    private void Start()
    {

        targetPoint = 0;

    }

    private void Update()
    {
        if(transform.position == patrolPoints[targetPoint].position)
        {
            IncreaseTargetInt();
        }
       transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, moveSpeed * Time.deltaTime);
    }

    private void IncreaseTargetInt()
    {
        targetPoint++;
        if(targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
