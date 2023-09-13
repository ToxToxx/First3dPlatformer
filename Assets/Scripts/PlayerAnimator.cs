using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnimator;

    private const string IS_WALKING_ANIMATION = "IsWalking";
    [SerializeField] private GameObject onJetpackVisual;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        StartWalking();
        StartFlyingJetpack();
    }

    private void StartWalking()
    {
        if (Player.Instance.GetIsWalking())
        {
            playerAnimator.SetBool(IS_WALKING_ANIMATION, true);
        }
        else
        {
            playerAnimator.SetBool(IS_WALKING_ANIMATION, false);
        }
    }

    private void StartFlyingJetpack()
    {
        if (Player.Instance.GetIsFlying())
        {
            onJetpackVisual.SetActive(true);
        }
        else
        {
            onJetpackVisual.SetActive(false);
        }
    }
}
