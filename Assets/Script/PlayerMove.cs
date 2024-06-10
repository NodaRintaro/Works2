using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    private Vector2 _dir = default;

    Transform _myTransform;

    void Update()
    {
        _myTransform = this.transform;
        float x = 0;
        float y = 0;
        _dir = new Vector2(x, y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var inputMove = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }

    public void OnFire(InputAction.CallbackContext context)
    {

    }
}
