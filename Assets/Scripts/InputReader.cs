using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputAction _clickAction;

    public event Action LeftMouseClicked;

    private void Awake()
    {
        _clickAction = new InputAction(binding: "<Mouse>/leftButton");
    }

    private void OnEnable()
    {
        if (_clickAction != null)
        {
            _clickAction.Enable();
            _clickAction.started += OnClickPerformed;
        }
    }

    private void OnDisable()
    {
        if (_clickAction != null)
        {
            _clickAction.started -= OnClickPerformed;
            _clickAction.Disable();
        }
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        LeftMouseClicked?.Invoke();
    }
}