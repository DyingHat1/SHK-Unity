using UnityEngine;
using UnityEngine.Events;

public class PlayerTimer : MonoBehaviour
{
    [SerializeField] private float _timerStartValue;

    private float _timer;

    public bool IsTimerOut { get; private set; }

    public event UnityAction TimeOut;

    private void Start()
    {
        IsTimerOut = false;
        _timer = _timerStartValue;
    }

    public void UpdateTimer()
    {
        if (IsTimerOut == false)
        {
            _timer -= Time.deltaTime;

            if (_timer < 0)
            {
                IsTimerOut = true;
                TimeOut?.Invoke();
            }
        }
    }

    public void RestartTimer()
    {
        _timer = _timerStartValue;
        IsTimerOut = false;
    }
}
