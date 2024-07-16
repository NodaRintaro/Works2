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
    [SerializeField] BulletType _bulletType;
    /// <summary>
    /// ターゲットのオブジェクト
    /// </summary>
    private GameObject _targetObject = null;

    private void Start()
    {
        _bulletType = GetComponent<BulletType>();
    }

    public void FixedUpdate()
    {
        if (_bulletType._bulletGroup == BulletType.BulletGroup.Enemy)
        {
            PlayerStatus.Instance.Damage(1);
            Destroy(this.gameObject);
        }//プレイヤーに当たったらこのオブジェクトを破壊してライフを減らす
        else if (_bulletType._bulletGroup == BulletType.BulletGroup.Player)
        {
            EnemyState.Instance.EnemyLife();
            Destroy(this.gameObject);
        }//敵に当たったらこのオブジェクトを破壊して敵のライフを減らす
        Debug.Log("hit");
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
        }
        else
        {
            return false;
        }
    }//プレイヤーと当たったらtrueを返す

    public void CheckDistance()
    {

    }
}
