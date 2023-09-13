using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    public static event EventHandler OnCoinDestroyed;
    [SerializeField] private int scorePoints;


 
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        PlayerScore.Instance.score += scorePoints;
    }



}
