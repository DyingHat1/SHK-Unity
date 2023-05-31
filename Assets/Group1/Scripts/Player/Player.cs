using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerTimer))]
public class Player : MonoBehaviour
{
    private PlayerTimer _timer;
    private PlayerMover _mover;

    private void Awake()
    {
        _timer = GetComponent<PlayerTimer>();
        _mover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _timer.TimeOut += OnTimeOut;
    }

    private void OnDisable()
    {
        _timer.TimeOut -= OnTimeOut;
    }

    private void Update()
    {
        _timer.UpdateTimer();
        _mover.TryMove();
    }

    public void OnEnemyDied()
    {
        _mover.TryChangeSpeed(ChangeType.Increase);
        _timer.RestartTimer();
    }

    private void OnTimeOut()
    {
        _mover.TryChangeSpeed(ChangeType.Reduce);
    }
}
