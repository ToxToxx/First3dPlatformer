using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    [SerializeField] private GameObjectPatrollingLogic gameObjectPatrollinglogic;
    [SerializeField] private float moveSpeed = 10f;


    void Update()
    {
        gameObjectPatrollinglogic.Patrolling(moveSpeed);
    }


  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {

            collision.gameObject.transform.SetParent(transform);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.transform.SetParent(null);

        }
    }
}
