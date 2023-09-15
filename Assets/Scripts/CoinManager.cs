using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static event Action<int> OnCoinDestroyed;
    public static CoinManager Instance { get; private set; }
    [SerializeField] private int totalCoins = 0;


    private void Awake()
    {
        Instance = this;
    }
    public  int GetCoinCount()
    {
        return totalCoins;
    }
    public void CoinDestroyed()
    {
        totalCoins++;
        OnCoinDestroyed?.Invoke(totalCoins); 
    }


}
