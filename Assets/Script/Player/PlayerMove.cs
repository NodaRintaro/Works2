using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの移動速度
    /// </summary>
    [SerializeField] float _movePower = 1f;

    /// <summary>
    /// ジャンプ力
    /// </summary>
    [SerializeField] float _jumpPower = 0.1f;

    /// <summary>
    /// プレイヤーのジャンプ力
    /// </summary>
    private float _riseSpeed;

    /// <summary>
    /// 弾丸のオブジェクト
    /// </summary>
    [SerializeField] GameObject _bullet = null;

    /// <summary>
    /// ジャンプの回数制限
    /// </summary>
    [SerializeField] int _maxJumpCount = 2;

    /// <summary>
    /// ジャンプをした回数
    /// </summary>
    private int _jumpCount = 0;

    /// <summary>
    /// 設置判定
    /// </summary>
    bool _isGround = true;

    private Vector3 _velocity;
    void Update()
    {
        transform.position += _velocity *_movePower * Time.deltaTime;
        // オブジェクトの移動処理

        transform.Translate(0f,_riseSpeed,0f);

        if (transform.position.y > -2.5 && _isGround == false )
        {
            _riseSpeed -= Time.deltaTime/2;
        }//空中にいる間徐々にジャンプ力を減少させて行く
        else
        {
            _riseSpeed = 0f;
            _isGround = true;
            _jumpCount = 0;
        }//着地したらジャンプ力、ジャンプカウント、設置判定をリセット
    }

    public void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();

        _velocity = new Vector3(axis.x, 0, 0);
    }//移動

    public void OnFire()
    {
        Instantiate(_bullet, this.transform.position, Quaternion.identity);
        Debug.Log("生成!");
    }//右クリックされたらBulletを生成

    public void OnJump()
    {
        if(_jumpCount != _maxJumpCount)
        {
            _riseSpeed = _jumpPower;
            _jumpCount++;
            _isGround = false;
        }
    }//InputSystemでジャンプの入力があればjumpPowerにジャンプ力の初期値を渡す
}
