using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの動く速度
    /// </summary>
    [SerializeField] float _movePower = 1f;

    /// <summary>
    /// プレイヤーのジャンプ力
    /// </summary>
    [SerializeField] float _jumpPower = 1f;

    /// <summary>
    /// 弾丸のオブジェクト
    /// </summary>
    [SerializeField] GameObject _bullet = null;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-_movePower, 0f, 0f);
            Debug.Log("左");
        }//キーの入力があれば左へ進む
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_movePower, 0f, 0f);
            Debug.Log("右");
        }//キーの入力があれば右へ進む
    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }

    public void OnFire(InputAction.CallbackContext context)
    {

    }
}
