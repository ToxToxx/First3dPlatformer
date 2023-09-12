using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    [SerializeField] private GameObjectPatrollingLogic gameObjectPatrollinglogic;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float playerBounceCoef = 0.25f;
    private Transform playerOnPlatform;



    // Update is called once per frame
    void Update()
    {
        gameObjectPatrollinglogic.Patrolling(moveSpeed);

        if (playerOnPlatform != null)
        {
            Vector3 relativePosition = playerOnPlatform.position - transform.position;
            playerOnPlatform.localPosition = relativePosition;
        }

    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            playerOnPlatform = other.transform;
            playerOnPlatform.SetParent(transform);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            playerOnPlatform.SetParent(null);
            playerOnPlatform = null;
            Player.Instance.BouncePlayer(playerBounceCoef);
        }
    }
}
