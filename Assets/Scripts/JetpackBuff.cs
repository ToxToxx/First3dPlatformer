using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackBuff : CollectibleItem
{
    [SerializeField] private int jetpackBuffCoef = 1;

    private void BuffJetpack()
    {
        PlayersJetpackLogic.Instance.SetJetpackMaxTimer(jetpackBuffCoef);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
            PlayerScore.Instance.score += scorePoints;
            BuffJetpack();

        }
    }
}
