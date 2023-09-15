using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathOfPlayer : MonoBehaviour
{
    public static DeathOfPlayer Instance { get; private set; }
    [SerializeField] private Player player;
    [SerializeField] private GameObject deathScreen;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        HideDeathScreen();
        player.OnPlayerDestroyed += Player_OnPlayerDestroyed;
    }

    private void Player_OnPlayerDestroyed(object sender, System.EventArgs e)
    {
        GameOver();
    }

    void Update()
    {
        if (player.gameObject == null)
        {
        }
        else
        {
            if (player.transform.position.y < -40)
            {
                GameOver();
            }
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        ShowDeathScreen();
    }


    private void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }
    private void HideDeathScreen()
    {
        deathScreen.SetActive(false);
    }
}
