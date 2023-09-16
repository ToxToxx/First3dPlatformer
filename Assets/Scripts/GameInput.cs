using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    public event EventHandler OnShiftPressed;
    public event EventHandler OnSpacePressed;
    public event EventHandler OnSavePressed;
    public event EventHandler OnLoadPressed;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Run.performed += Run_performed;
        playerInputActions.Player.Jump.performed += Jump_performed;
        playerInputActions.Player.Save.performed += Save_performed;
        playerInputActions.Player.Load.performed += Load_performed;

    }

    private void Load_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnLoadPressed?.Invoke(this, EventArgs.Empty);
    }

    private void Save_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSavePressed?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {

        playerInputActions.Player.Run.performed -= Run_performed;
        playerInputActions.Player.Jump.performed -= Jump_performed;
        playerInputActions.Player.Save.performed -= Save_performed;
        playerInputActions.Player.Load.performed -= Load_performed;

        playerInputActions.Dispose();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnSpacePressed?.Invoke(this,EventArgs.Empty);
    }

    private void Run_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnShiftPressed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {     
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }




}
