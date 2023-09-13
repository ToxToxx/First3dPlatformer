using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnimator;

    private const string IS_WALKING_ANIMATION = "IsWalking";


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        StartWalking();
        
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

    
}
