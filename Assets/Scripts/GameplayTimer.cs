using System;
using System.Collections;
using UnityEngine;

public class GameplayTimer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private readonly WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private int _counter = 0;
    private bool _isRunning = false;
    private Coroutine _counterCoroutine;

    public event Action<int> OnCounterChanged;

    private void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.OnLeftMouseClick += ToggleCounter;
        }
    }

    private void OnDisable()
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
                _counterCoroutine = null;
            }
        }
    }

    private IEnumerator CountRoutine()
    {
        while (_isRunning)
        {
            _counter++;
            OnCounterChanged?.Invoke(_counter);
            yield return _delay;
        }
    }
}