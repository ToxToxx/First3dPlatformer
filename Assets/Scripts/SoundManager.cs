using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private float _volume = 1.0f;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnSpacePressed += GameInput_OnSpacePressed;
        GameInput.Instance.OnShiftPressed += GameInput_OnShiftPressed;
        CoinManager.OnCoinDestroyed += CoinManager_OnCoinDestroyed;
        Player.Instance.OnPlayerDestroyed += Player_OnPlayerDestroyed;
        PlayersJetpackLogic.Instance.OnJeptackLaunch += PlayersJetpackLogic_OnJeptackLaunch;
    }

    private void PlayersJetpackLogic_OnJeptackLaunch(object sender, System.EventArgs e)
    {     
        PlaySound(audioClipRefsSO.onJetpackLaunchSound, Player.Instance.transform.position);
    }

    private void Player_OnPlayerDestroyed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.onDeathSound, Player.Instance.transform.position);
    }

    private void CoinManager_OnCoinDestroyed(int obj)
    {
        PlaySound(audioClipRefsSO.coinCollectSound, Player.Instance.transform.position);
    }

    private void GameInput_OnShiftPressed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.sprintSound, Player.Instance.transform.position);
    }

    private void GameInput_OnSpacePressed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.jumpSound, Player.Instance.transform.position);
    }


    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * _volume);
    }

    private void OnDestroy()
    {
        GameInput.Instance.OnSpacePressed -= GameInput_OnSpacePressed;
        GameInput.Instance.OnShiftPressed -= GameInput_OnShiftPressed;
        CoinManager.OnCoinDestroyed -= CoinManager_OnCoinDestroyed;
        Player.Instance.OnPlayerDestroyed -= Player_OnPlayerDestroyed;
        PlayersJetpackLogic.Instance.OnJeptackLaunch -= PlayersJetpackLogic_OnJeptackLaunch;
    }
}
