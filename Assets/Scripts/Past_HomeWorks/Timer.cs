using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Timer : MonoBehaviour
{
    public static event Action OnMouseClick;

    private int _counter = 0;
    private bool _isRunning = false;
    private Coroutine _counterCoroutine;

    void OnEnable()
    {
        OnMouseClick += ToggleCounter;
    }

    void OnDisable()
    {
        OnMouseClick -= ToggleCounter;
    }

     void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            OnMouseClick?.Invoke();
        }
    }

    private void ToggleCounter()
    {
        _isRunning = !_isRunning;

        if (_isRunning)
        {
            _counterCoroutine = StartCoroutine(CountRoutine());
        }
        else
        {
            if (_counterCoroutine != null)
            {
                StopCoroutine(_counterCoroutine);
            }
        }
    }

    private IEnumerator CountRoutine()
    {
        while (_isRunning)
        {
            _counter++;

            Debug.Log("Таймер: " + _counter);
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}