using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class BulletCollider : MonoBehaviour
{
    public EnemyList _enemyList = new EnemyList();
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
    [SerializeField] BulletGroup _bulletGroup;
    /// <summary>
    /// ターゲットのオブジェクト
    /// </summary>
    private GameObject _targetObject = null;

    private void Awake()
    {
        if (_bulletGroup == BulletGroup.Enemy)
        {
            _targetObject = GameObject.FindWithTag("Player");
        }// プレイヤーのオブジェクトを探す
        else
        {
            _targetObject = CheckTarget(EnemyList.Instance._targetList);
        }
    }

    public void LateUpdate()
    {
        switch (_bulletGroup)
        {
            case BulletGroup.Enemy:
                if (CheckHit(_targetObject))
                {
                    Destroy(this.gameObject);
                    Debug.Log("Hit");
                }//敵の球がプレイヤーに当たったらこのオブジェクトを破壊してライフを減らす
                break;
            case BulletGroup.Player:
                if (CheckHit(CheckTarget(EnemyList.Instance._targetList)))
                {
                    Destroy(this.gameObject);
                    Debug.Log("Hit");
                }//プレイヤーの球が敵に当たったらこのオブジェクトを破壊して敵のライフを減らす
                break;
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
    }//ターゲットと当たったらtrueを返す当たり判定

    public GameObject CheckTarget(List<GameObject>targetList)
    {
        float targetDistance = default;
        foreach (GameObject target in targetList)
        {
            float thisDistance = Vector3.Distance(target.transform.position, this.transform.position);
            if (targetDistance > thisDistance)
            {
                targetDistance = thisDistance;
                _targetObject = target;
            }
            else if (targetDistance == default)
            {
                targetDistance = thisDistance;
                _targetObject = target;
            }
        }
        return _targetObject;
    }//一番距離が近い敵をターゲットにする

    /// <summary>
    /// 球がプレイヤーかエネミーどちらから放たれたものかの判定
    /// </summary>
    public enum BulletGroup
    {
        Enemy,
        Player
    }
}
