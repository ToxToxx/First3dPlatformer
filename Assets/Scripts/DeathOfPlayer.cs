using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOfPlayer : MonoBehaviour
{
    [SerializeField] private Player player;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -40)
        {
            Destroy(player.gameObject);
        }
    }
}
