using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private Vector2 _inputVector;
    private PlayerInputActions playerInputActions;

    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVector()
    {
        _inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        _inputVector = _inputVector.normalized;

        return _inputVector;
    }
}
