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

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        JetpackLaunch();
    }

    private void JetpackLaunch()
    {
        if (Player.Instance.GetIsOnEarth())
        {
            Player.Instance.SetIsFlying(false);
            ReduceFlyingTimer();
        }
        else
        {
            movementVectorY = GameInput.Instance.GetMovementVectorNormalized().y;
            if (movementVectorY >= 0.1 && !Player.Instance.GetIsFlying() && flyingTimer <= 0.1)
            {
                Player.Instance.SetIsFlying(true);
            }

            if (Player.Instance.GetIsFlying())
            {

                Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
                Vector3 moveDir = new(0f, inputVector.y, 0f);
                transform.position += jetpackForceCoef * Time.deltaTime * moveDir;
                flyingTimer += Time.deltaTime;
                if (flyingTimer > maxFlyingTimer)
                {
                    Player.Instance.SetIsFlying(false);
                }

            }
            else if (!Player.Instance.GetIsFlying())
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
}
