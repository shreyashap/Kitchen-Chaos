using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float rotationSpeed = 5f;
    private Vector2 _inputVector;
    private Vector3 _moveDir;
    private bool _isWalking;

    [SerializeField] private GameInput gameInput;
    // Update is called once per frame
    void Update()
    {
        _inputVector = gameInput.GetMovementVector();

        

        _moveDir = new Vector3(_inputVector.x, 0, _inputVector.y);
        transform.position += _moveDir * _speed * Time.deltaTime;

        _isWalking = _moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, _moveDir, Time.deltaTime * rotationSpeed);
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}
