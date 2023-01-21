using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerGunController : MonoBehaviour
{
    // control of the gun class and using them


    public void OnMoveInput(InputAction.CallbackContext context)
    {

    }

    public void OnDodgeInput(InputAction.CallbackContext context)
    {

    }
    private void SubscribeToActions()
    {
        InputManager inputManager = RefManager.inputManager;
        inputManager.OnMove += OnMoveInput;
    }

    private void UnSubscribeToActions()
    {
        // Unsubscribe to actions
    }

    private void OnDestroy() {
        UnSubscribeToActions();
    }
}