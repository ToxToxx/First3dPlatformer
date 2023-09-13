using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObjectPatrollingLogic gameObjectPatrollinglogic;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotatingSpeed = 60;


    private void Update()
    {
        gameObjectPatrollinglogic.Patrolling(moveSpeed);
        RotateEnemy();

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
        Vector3 moveDir = gameObjectPatrollinglogic.GetTransformPosition();

        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotatingSpeed * Time.deltaTime);
        }
    }
}
