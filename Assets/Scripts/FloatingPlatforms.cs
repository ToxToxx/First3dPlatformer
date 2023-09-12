using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    [SerializeField] private GameObjectPatrollingLogic gameObjectPatrollinglogic;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float playerBounceCoef = 0.25f;




    // Update is called once per frame
    void Update()
    {
        gameObjectPatrollinglogic.Patrolling(moveSpeed);


    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {

            other.transform.parent = transform;
            Player.Instance.BouncePlayer(playerBounceCoef);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.transform.parent = null;
            
        }
    }
}
