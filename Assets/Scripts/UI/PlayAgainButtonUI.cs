using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButtonUI : MonoBehaviour
{
    [SerializeField] private Button _playAgainButton;


    private void Awake()
    {
        _playAgainButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
        Time.timeScale = 1;
    }
}
