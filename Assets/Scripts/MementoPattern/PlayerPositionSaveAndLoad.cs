using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPositionSaveAndLoad : MonoBehaviour
{
    [SerializeField] private GameHistory gameHistory;


    private void Start()
    {
        
        GameInput.Instance.OnSavePressed += GameInput_OnSavePressed;
        GameInput.Instance.OnLoadPressed += GameInput_OnLoadPressed;
    }

    private void GameInput_OnLoadPressed(object sender, EventArgs e)
    {
        Debug.Log("Load");
        Player.Instance.RestoreState(gameHistory.History.Pop());
    }

    private void GameInput_OnSavePressed(object sender, EventArgs e)
    {
        Debug.Log("Save");
        gameHistory.History.Push(Player.Instance.SaveState());
    }



}
