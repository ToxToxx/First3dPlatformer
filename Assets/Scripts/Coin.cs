using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : CollectibleItem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
            PlayerScore.Instance.score += scorePoints;
        }
    }

    private void OnDestroy()
    {
        CoinManager.Instance.CoinDestroyed();
    }
}
