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
        HandleMovement();
        HandleInteraction();
    }

    public bool IsWalking()
    {
        return _isWalking;
    }

    private void HandleMovement()
    {
        _inputVector = gameInput.GetMovementVector();

        float playerRadius = .7f;
        float playerHeight = 2f;
        float moveDistance = _speed * Time.deltaTime;

        _moveDir = new Vector3(_inputVector.x, 0, _inputVector.y);
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, _moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(_moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                _moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, _moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    _moveDir = moveDirZ;
                }

            }

        }

        if (canMove)
        {
            transform.position += _moveDir * moveDistance;
        }


        _isWalking = _moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, _moveDir, Time.deltaTime * rotationSpeed);
    }
    
    private void HandleInteraction()
    {

    }
}
