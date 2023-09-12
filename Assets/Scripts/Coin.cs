using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event EventHandler OnCoinDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        OnCoinDestroyed?.Invoke(this, EventArgs.Empty); 
    }

}
