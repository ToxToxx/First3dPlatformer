using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnimator;

    private const string IS_WALKING_ANIMATION = "IsWalking";

    private const string IS_FLYING_ANIMATION = "IsFlying";


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        StartWalking();

        StartFlying();
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

    private void StartFlying()
    {
        if (Player.Instance.GetIsFlying() || Player.Instance.GetIsJumping())
        {
            playerAnimator.SetBool(IS_FLYING_ANIMATION, true);
        }
        else
        {
            playerAnimator.SetBool(IS_FLYING_ANIMATION, false);
        }
    }

    
}
