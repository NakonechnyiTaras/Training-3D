using System;
using System.Collections;
using UnityEngine;

public class CustomGameplayTimer : MonoBehaviour
{
    public event Action<int> OnCounterChanged;

    [SerializeField] private CustomInputReader _inputReader;

    private int _counter = 0;
    private bool _isRunning = false;
    private Coroutine _counterCoroutine;

    void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.OnLeftMouseClick += ToggleCounter;
        }
    }

    void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.OnLeftMouseClick -= ToggleCounter;
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
            OnCounterChanged?.Invoke(_counter);
            yield return new WaitForSeconds(0.5f);
        }
    }
}