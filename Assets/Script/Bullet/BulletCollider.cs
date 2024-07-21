using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    /// <summary>
    /// ターゲットのリスト
    /// </summary>
    [SerializeField] List<GameObject> _targetList = new List<GameObject>();
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
    [SerializeField] public BulletGroup _bulletGroup;
    /// <summary>
    /// ターゲットのオブジェクト
    /// </summary>
    private GameObject _targetObject = null;

    public void FixedUpdate()
    {
        if (CheckHit(_targetObject))
        {
            if (_bulletGroup == BulletGroup.Enemy)
            {
                PlayerStatus.Instance.Damage();
                Destroy(this.gameObject);
            }//プレイヤーに当たったらこのオブジェクトを破壊してライフを減らす
            else if (_bulletGroup == BulletGroup.Player)
            {
                _targetObject.EnemyState.Damage(1);
                Destroy(this.gameObject);
            }//敵に当たったらこのオブジェクトを破壊して敵のライフを減らす
            Debug.Log("hit");
        }
    }

    public bool CheckHit(GameObject target)
    {
        _targetPos = target.transform.position;
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
        }
        else
        {
            return false;
        }
    }//プレイヤーと当たったらtrueを返す

    public void CheckDistance()
    {

    }

    public enum BulletGroup
    {
        Enemy,
        Player
    }
}
