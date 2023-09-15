using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathOfPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject deathScreen;

 
    private void Start()
    {
        deathScreen.SetActive(false);
    }
    void Update()
    {
        if (player.transform.position.y < -40)
        {
            Destroy(player.gameObject);
        }
    }

    private void OnDestroy()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
