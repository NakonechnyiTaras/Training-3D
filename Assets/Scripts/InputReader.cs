using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputAction _clickAction;

    public event Action OnLeftMouseClick;

    private void Awake()
    {
        _clickAction = new InputAction(binding: "<Mouse>/leftButton");
    }

    private void OnEnable()
    {
        if (_clickAction != null)
        {
            _clickAction.Enable();
            _clickAction.performed += OnClickPerformed;
        }
    }

    private void OnDisable()
    {
        if (_clickAction != null)
        {
            _clickAction.performed -= OnClickPerformed;
            _clickAction.Disable();
        }
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        OnLeftMouseClick?.Invoke();
    }
}