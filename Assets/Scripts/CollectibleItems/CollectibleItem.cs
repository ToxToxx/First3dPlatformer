using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectibleItem : MonoBehaviour
{

    [SerializeField] protected int scorePoints;


 
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        PlayerScore.Instance.score += scorePoints;
    }



}
