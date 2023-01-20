using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using System;
public class InputManager : MonoBehaviour
{

    public Action<CallbackContext> OnMove = delegate { };
    public Action<CallbackContext> OnAim = delegate { };
    public Action<CallbackContext> OnPrimary = delegate { };
    public Action<CallbackContext> OnSecondary = delegate { };
    public Action<CallbackContext> OnDodge = delegate { };
    public Action<CallbackContext> OnSwapWeapon = delegate { };
    public Action<CallbackContext> OnInteract = delegate { };
    private void Awake()
    {
        if (RefManager.inputManager != null)
        {
            Destroy(gameObject);
            return;
        }
        RefManager.inputManager = this;
    }

    private void Start()
    {
        SubscribeToActions();
    }

    private void SubscribeToActions()
    {
        var playerInput = GetComponent<PlayerInput>();
        var actions = playerInput.actions;
        actions["Move"].started += OnMoveInput;
        actions["Move"].performed += OnMoveInput;
        actions["Move"].canceled += OnMoveInput;
        actions["Aim"].started += OnAimInput;
        actions["Aim"].performed += OnAimInput;
        actions["Aim"].canceled += OnAimInput;
        actions["Primary"].started += OnPrimaryInput;
        actions["Primary"].performed += OnPrimaryInput;
        actions["Primary"].canceled += OnPrimaryInput;
        actions["Secondary"].started += OnSecondaryInput;
        actions["Secondary"].performed += OnSecondaryInput;
        actions["Secondary"].canceled += OnSecondaryInput;
        actions["Dodge"].started += OnDodgeInput;
        actions["Dodge"].performed += OnDodgeInput;
        actions["Dodge"].canceled += OnDodgeInput;
        actions["SwapWeapon"].started += OnSwapWeaponInput;
        actions["SwapWeapon"].performed += OnSwapWeaponInput;
        actions["SwapWeapon"].canceled += OnSwapWeaponInput;
        actions["Interact"].started += OnInteractInput;
        actions["Interact"].performed += OnInteractInput;
        actions["Interact"].canceled += OnInteractInput;
    }

    private void UnSubscribeToActions()
    {
        var playerInput = GetComponent<PlayerInput>();
        var actions = playerInput.actions;
        actions["Move"].started -= OnMoveInput;
        actions["Move"].performed -= OnMoveInput;
        actions["Move"].canceled -= OnMoveInput;
        actions["Aim"].started -= OnAimInput;
        actions["Aim"].performed -= OnAimInput;
        actions["Aim"].canceled -= OnAimInput;
        actions["Primary"].started -= OnPrimaryInput;
        actions["Primary"].performed -= OnPrimaryInput;
        actions["Primary"].canceled -= OnPrimaryInput;
        actions["Secondary"].started -= OnSecondaryInput;
        actions["Secondary"].performed -= OnSecondaryInput;
        actions["Secondary"].canceled -= OnSecondaryInput;
        actions["Dodge"].started -= OnDodgeInput;
        actions["Dodge"].performed -= OnDodgeInput;
        actions["Dodge"].canceled -= OnDodgeInput;
        actions["SwapWeapon"].started -= OnSwapWeaponInput;
        actions["SwapWeapon"].performed -= OnSwapWeaponInput;
        actions["SwapWeapon"].canceled -= OnSwapWeaponInput;
        actions["Interact"].started -= OnInteractInput;
        actions["Interact"].performed -= OnInteractInput;
        actions["Interact"].canceled -= OnInteractInput;
    }

    private void OnDestroy()
    {
        UnSubscribeToActions();
    }
    public void OnMoveInput(CallbackContext context)
    {
        OnMove(context);
    }

    public void OnAimInput(CallbackContext context)
    {
        OnAim(context);
    }

    public void OnPrimaryInput(CallbackContext context)
    {
        OnPrimary(context);
    }

    public void OnSecondaryInput(CallbackContext context)
    {
        OnSecondary(context);
    }

    public void OnDodgeInput(CallbackContext context)
    {
        OnDodge(context);
    }

    public void OnSwapWeaponInput(CallbackContext context)
    {
        OnSwapWeapon(context);
    }

    public void OnInteractInput(CallbackContext context)
    {
        OnInteract(context);
    }
}