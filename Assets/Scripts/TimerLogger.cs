using UnityEngine;

public class TimerLogger : MonoBehaviour
{
    [SerializeField] private GameplayTimer _timer;

    private void OnEnable()
    {
        if (_timer != null)
        {
            _timer.OnCounterChanged += DisplayCounter;
        }
    }

    private void OnDisable()
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