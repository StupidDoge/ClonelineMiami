using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 7.0f;

    private bool _isMoving;
    private bool _allowMoving = true;
    private float _verticalMovement, _horizontalMovement;

    public bool IsMoving => _isMoving;

    private void Update()
    {
        if (_allowMoving)
            Move();
        MovementCheck();
        _animator.SetBool("isMoving", _isMoving);
    }

    public void setMovement(bool val)
    {
        _allowMoving = val;
    }

    private void Move()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");

        if (_isMoving)
        {
            Vector2 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement).normalized;
            transform.Translate(targetVelocity * _speed * Time.deltaTime, Space.World);
        }
    }

    private void MovementCheck()
    {
        if (_horizontalMovement == 0 && _verticalMovement == 0)
            _isMoving = false;
        else
            _isMoving = true;
    }
}
