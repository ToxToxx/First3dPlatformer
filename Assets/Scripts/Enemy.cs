using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObjectPatrollingLogic gameObjectPatrollinglogic;
    [SerializeField] private float moveSpeed = 10f;


    private void Start()
    {


    }

    private void Update()
    {
        gameObjectPatrollinglogic.Patrolling(moveSpeed);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
           Destroy(collision.gameObject);
        }
    }
}