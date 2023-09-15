using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackVisual : MonoBehaviour
{
    [SerializeField] private GameObject onJetpackVisual;
    [SerializeField] private GameObject offJetpackVisual;
   


    void Update()
    {
        StartFlyingJetpack();
    }

    private void StartFlyingJetpack()
    {
        if (PlayersJetpackLogic.Instance.GetIsFLying())
        {
            onJetpackVisual.SetActive(true);
            offJetpackVisual.SetActive(false);
        }
        else
        {
            onJetpackVisual.SetActive(false);
            offJetpackVisual.SetActive(true);
        }
    }
}
