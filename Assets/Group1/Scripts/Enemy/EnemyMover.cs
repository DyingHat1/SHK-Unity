using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _targetRadius;
    [SerializeField] private float _speed;

    private Vector3 Target;

    private void Start()
    {
        SetNewTarget();
    }

    public void Move()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, _speed * Time.deltaTime);

        if (transform.position == Target)
            SetNewTarget();
    }

    private void SetNewTarget()
    {
        Target = Random.insideUnitCircle * _targetRadius;
    }
}
