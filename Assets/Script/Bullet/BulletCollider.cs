using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        }
    }

    public void FixedUpdate()
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
                CheckTarget(EnemyList.Instance._targetList, _targetObject);
                if (CheckHit(_targetObject))
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
    }//プレイヤーと当たったらtrueを返す

    public void CheckTarget(List<GameObject>targetList,GameObject currentTarget)
    {
        float closestDistance = 1000;
        float currentDistance;
        _thisPos = this.transform.position;
        foreach(GameObject target in targetList)
        {
            if(target != null)
            {
                currentDistance = Vector3.Distance(target.transform.position, _thisPos);
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    currentTarget = target;
                }
            }
        }
    }//ターゲットが複数いた場合一番距離が近いものをターゲットとする

    public enum BulletGroup
    {
        Enemy,
        Player
    }
}
