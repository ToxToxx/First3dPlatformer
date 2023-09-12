using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    [SerializeField] private GameObjectPatrollingLogic gameObjectPatrollinglogic;
    [SerializeField] private float moveSpeed = 10f;



    // Update is called once per frame
    void Update()
    {
        gameObjectPatrollinglogic.Patrolling(moveSpeed);
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.transform.SetParent(transform, true);
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.transform.SetParent(null);

        }
    }
}
