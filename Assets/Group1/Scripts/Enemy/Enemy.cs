using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _deathDistance;
    [SerializeField] private Player _player;

    private EnemyMover _mover;

    public event UnityAction<Enemy> Dead;

    private void Start()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        _mover.Move();

        if (GetDistanceToPlayer() <= _deathDistance)
            Die();
    }

    private float GetDistanceToPlayer()
    {
        return Vector3.Distance(transform.position, _player.transform.position);
    }

    private void Die()
    {
        Dead?.Invoke(this);
        _player.OnEnemyDied();
        Destroy(gameObject);
    }
}
