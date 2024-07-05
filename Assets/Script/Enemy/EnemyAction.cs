using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    /// <summary>
    /// ターゲットとなるプレイヤーのオブジェクト
    /// </summary>
    [SerializeField] GameObject _targetObject = null;
    /// <summary>
    /// 弾丸のオブジェクト
    /// </summary>
    [SerializeField] GameObject _bullet = null;
    /// <summary>
    /// ターゲットにむけて発砲を開始する距離
    /// </summary>
    [SerializeField] float _rangeDistance = 5;
    /// <summary>
    /// プレイヤーとの距離
    /// </summary>
    private float _distance;
    /// <summary>
    /// このオブジェクトの位置
    /// </summary>
    private Vector2 _thisObjectPosition;
    /// <summary>
    /// ターゲットとなるプレイヤーの位置
    /// </summary>
    private Vector2 _targetObjectPosition;
    /// <summary>
    /// Bulletの発射インターバル
    /// </summary>
    private float _fireDistance = 1;
    /// <summary>
    /// タイマー
    /// </summary>
    private float _timer = 0;

    private void Start()
    {
        _thisObjectPosition = this.gameObject.transform.position;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _targetObjectPosition = _targetObject.transform.position;
        _distance = Vector3.Distance(_targetObjectPosition, _thisObjectPosition);
        if(_timer >= _fireDistance && _distance <= _rangeDistance)
        {
            _timer = 0;
            Instantiate(_bullet,_thisObjectPosition, Quaternion.identity);
        }
    }//プレイヤーが射程距離に入ったら発砲を開始する処理
}
