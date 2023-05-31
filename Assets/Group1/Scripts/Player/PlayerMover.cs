using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedChangeCoefficient;

    private float _maxSpeed;
    private float _minSpeed;

    private void Start()
    {
        _maxSpeed = _speed;
        _minSpeed = _speed / _speedChangeCoefficient;
    }

    public void TryMove()
    {
        if (Input.GetKey(KeyCode.W))
            Move(Vector3.up);
        

        if (Input.GetKey(KeyCode.S))
            Move(Vector3.down);
        

        if (Input.GetKey(KeyCode.A))
            Move(Vector3.left);

        if (Input.GetKey(KeyCode.D))
            Move(Vector3.right);
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public bool TryChangeSpeed(ChangeType type)
    {
        if (type == ChangeType.Increase && _speed != _maxSpeed)
        {
            _speed *= _speedChangeCoefficient;
            return true;
        }

        if (type == ChangeType.Reduce && _speed != _minSpeed)
        {
            _speed /= _speedChangeCoefficient;
            return true;
        }

        return false;
    }
}

public enum ChangeType
{
    Increase,
    Reduce
}
