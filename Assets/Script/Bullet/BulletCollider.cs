using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletType;

public class BulletCollider : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのオブジェクト
    /// </summary>
    [SerializeField] GameObject _targetObject;
    /// <summary>
    /// このオブジェクトの位置
    /// </summary>
    [SerializeField] private Vector2 _thisPos;
    /// <summary>
    /// プレイヤーの位置
    /// </summary>
    [SerializeField] private Vector2 _targetPos;
    /// <summary>
    /// このオブジェクトの大きさ
    /// </summary>
    [SerializeField] float _thisObjectScale;
    /// <summary>
    /// プレイヤーの半径
    /// </summary>
    [SerializeField] float _playerRadius = 0.5f;
    /// <summary>
    /// X軸のプレイヤーとの距離
    /// </summary>
    [SerializeField] private float _xDistance;
    /// <summary>
    /// Y軸のプレイヤーとの距離
    /// </summary>
    [SerializeField] private float _yDistance;
    /// <summary>
    /// 球の種類
    /// </summary>
    private BulletType _bulletType;

    private void Start()
    {
        _bulletType = this.gameObject.GetComponent<BulletType>();
    }

    public void Update()
    {
        if (CheckHit() && _bulletType._bulletGroup == BulletGroup.Player)
        {
            PlayerStatus.Instance.Life(1);
            Destroy(this.gameObject);
            if(_bulletType._bulletGroup == BulletGroup.Player)
                PlayerStatus.Instance.Life(1);
            //プレイヤーに当たったらこのオブジェクトを破壊してライフを減らす
            else if (_bulletType._bulletGroup == BulletGroup.Enemy)
                EnemyState.Instance.EnemyLife();
            //敵に当たったらこのオブジェクトを破壊して敵のライフを減らす
        }
    }

    public bool CheckHit()
    {
        _targetPos = _targetObject.transform.position;
        _thisPos = this.transform.position;
        _xDistance = _thisPos.x - _targetPos.x;
        _yDistance = _thisPos.y - _targetPos.y;
        if(_xDistance < 0)
        {
            _xDistance *= -1;
        }
        if(_yDistance < 0)
        {
            _yDistance *= -1;
        }
        if (_xDistance < _thisObjectScale + _playerRadius && _yDistance < _thisObjectScale + _playerRadius)
        {
            return true;
            Debug.Log("hit");
        }
        else
        {
            return false;
        }
    }//プレイヤーと当たったらtrueを返す
}
