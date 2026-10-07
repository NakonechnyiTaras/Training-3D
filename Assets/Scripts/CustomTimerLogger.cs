using UnityEngine;

public class CustomTimerLogger : MonoBehaviour
{
    [SerializeField] private CustomGameplayTimer _timer;

    void OnEnable()
    {
        if (_timer != null)
        {
            _timer.OnCounterChanged += DisplayCounter;
        }
    }

    void OnDisable()
    {
        if (_timer != null)
        {
            _timer.OnCounterChanged -= DisplayCounter;
        }
    }

    private void DisplayCounter(int currentCount)
    {
        Debug.Log("Таймер: " + currentCount);
    }
}