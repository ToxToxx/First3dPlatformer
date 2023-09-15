using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalCoinsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    

    private void Start()
    {

    }

    private void Coin_OnCoinDestroyed(object sender, System.EventArgs e)
    {

    }

    private void Update()
    {
        totalCoinsText.text = "TOTAL COINS: " + CoinManager.Instance.GetCoinCount();
    }
}
