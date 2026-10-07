using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputReader : MonoBehaviour
{
    public event Action OnLeftMouseClick;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            OnLeftMouseClick?.Invoke();
        }
    }
}