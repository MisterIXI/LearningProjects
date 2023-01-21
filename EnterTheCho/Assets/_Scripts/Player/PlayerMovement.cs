using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movementInput;
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D rb;
    [SerializeField] private float _DodgeRollDistance= 10f;
    private void Start() {
        SubscribeToActions();
        rb = GetComponent<Rigidbody2D>();
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
        // start animation
        Debug.Log("DODGE ROLL");
        Debug.Log("previous: rb.Position: "+ rb.position + " MOVEDOGE: " + _movementInput *_DodgeRollDistance);
        rb.MovePosition(rb.position + _movementInput *_DodgeRollDistance);
        Debug.Log("current: rb.Position: "+ rb.position + " MOVEDOGE: " + _movementInput *_DodgeRollDistance);
    }
    
    private void FixedUpdate() {
        // rb.MovePosition(rb.position + _movementInput * _movementSpeed * Time.fixedDeltaTime);
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
