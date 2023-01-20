using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movementInput;

    private void Start() {
        SubscribeToActions();
    }
    // movement including walking, dodging, effects like slow, sprinting, etc.
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        // if ( controller ) context.performed = Vector2.normalized 
        if(context.performed)
        {
            _movementInput = context.ReadValue<Vector2>();
        }
        else if(context.canceled) // INPUT ENDS
        {
            _movementInput = Vector2.zero;
        }
    }

    public void OnDodgeInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Dodge();
        }
    }
    private void Dodge()
    {

    }

    private void SubscribeToActions()
    {
        InputManager inputManager = RefManager.inputManager;
        inputManager.OnMove += OnMoveInput;
        inputManager.OnDodge += OnDodgeInput;
    }

    private void UnSubscribeToActions()
    {
        InputManager inputManager = RefManager.inputManager;
        inputManager.OnMove -= OnMoveInput;
        inputManager.OnDodge -= OnDodgeInput;
    }

    private void OnDestroy()
    {
        UnSubscribeToActions();
    }
}
