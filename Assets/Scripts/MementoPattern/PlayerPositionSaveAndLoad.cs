using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPositionSaveAndLoad : MonoBehaviour
{
    [SerializeField] private GameHistory gameHistory;
    private bool isStackEmpty;

    private void Start()
    {
        GameInput.Instance.OnSavePressed += GameInput_OnSavePressed;
        GameInput.Instance.OnLoadPressed += GameInput_OnLoadPressed;
        isStackEmpty = true;
    }

    private void GameInput_OnLoadPressed(object sender, EventArgs e)
    {
        if(!isStackEmpty)
        {
            Debug.Log("Load");
            Player.Instance.RestoreState(gameHistory.History.Pop());
            isStackEmpty = true;
        }
        else
        {
            Debug.Log("No saving data");
        }
    }

    private void GameInput_OnSavePressed(object sender, EventArgs e)
    {
        Debug.Log("Save");
        gameHistory.History.Push(Player.Instance.SaveState());
        isStackEmpty = false;
    }
    private void OnDestroy()
    {
        GameInput.Instance.OnSavePressed -= GameInput_OnSavePressed;
        GameInput.Instance.OnLoadPressed -= GameInput_OnLoadPressed;
    }




}
