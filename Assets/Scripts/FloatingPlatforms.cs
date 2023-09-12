using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    [SerializeField] private GameObjectPatrollingLogic gameObjectPatrollinglogic;
    [SerializeField] private float moveSpeed = 10f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObjectPatrollinglogic.Patrolling(moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.transform.SetParent(transform, true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.transform.SetParent(transform, false);
        }
    }
}
