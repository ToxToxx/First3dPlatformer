using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTimeFlyingProgressionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerTimeFlyTextUI;

    private void Update()
    {
        playerTimeFlyTextUI.text = "Max Time Flying: " + PlayersJetpackLogic.Instance.GetMaxFlyingTimer();
    }
}
