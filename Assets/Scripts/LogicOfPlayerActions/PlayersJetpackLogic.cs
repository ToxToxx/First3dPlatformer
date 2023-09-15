using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersJetpackLogic : MonoBehaviour
{
    public static PlayersJetpackLogic Instance;

    [SerializeField] private float maxFlyingTimer = 2f;
    [SerializeField] private float flyingTimer = 0;
    [SerializeField] private float jetpackForceCoef = 100f;
    [SerializeField] private float movementVectorY;
    [SerializeField] private bool isFlying;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        isFlying = false;
    }
    void Update()
    {
        JetpackLaunch();
    }

    private void JetpackLaunch()
    {
        if (Player.Instance.GetIsOnEarth())
        {
            isFlying = false;
            ReduceFlyingTimer();
        }
        else
        {
            movementVectorY = GameInput.Instance.GetMovementVectorNormalized().y;
            if (movementVectorY >= 0.1 && !isFlying && flyingTimer <= 0.1)
            {
                isFlying = true;
            }

            if (isFlying)
            {

                Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
                Vector3 moveDir = new(0f, inputVector.y, 0f);
                transform.position += jetpackForceCoef * Time.deltaTime * moveDir;
                flyingTimer += Time.deltaTime;
                if (flyingTimer > maxFlyingTimer)
                {
                    isFlying = false;
                }

            }
            else if (!isFlying)
            {

                ReduceFlyingTimer();
            }

        }
    }

    private void ReduceFlyingTimer()
    {
        if (flyingTimer > 0)
        {
            flyingTimer -= Time.deltaTime;
        }
        else
        {
            flyingTimer = 0;
        }
    }
    public void SetJetpackMaxTimer(float jetpackBuff)
    {
        this.maxFlyingTimer += jetpackBuff;
    }
    public float GetJetpackMaxTimer()
    {

        return maxFlyingTimer;
    }
    public float GetFlyingTimer()
    {
        return flyingTimer;
    }
    public float GetMaxFlyingTimer()
    {
        return maxFlyingTimer;
    }
    public bool GetIsFLying()
    {
        return isFlying;
    }
}
