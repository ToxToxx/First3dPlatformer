using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackVisual : MonoBehaviour
{
    [SerializeField] private GameObject onJetpackVisual;
    [SerializeField] private GameObject offJetpackVisual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartFlyingJetpack();
    }

    private void StartFlyingJetpack()
    {
        if (Player.Instance.GetIsFlying())
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
