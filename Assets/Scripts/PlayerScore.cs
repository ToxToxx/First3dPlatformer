using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance {  get; private set; }  
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int score = 0;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
        Coin.OnCoinDestroyed += Coin_OnCoinDestroyed;
    }

    private void Coin_OnCoinDestroyed(object sender, System.EventArgs e)
    {
        score++;
    }


    public int GetScore()
    {
        return score;
    }
}
