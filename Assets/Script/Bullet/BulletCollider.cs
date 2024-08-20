using System.Collections.Generic;
using UnityEngine;
public class BulletCollider : MonoBehaviour
{
    public EnemyList _enemyList;
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
    /// <summary>
    /// enemyのStatus
    /// </summary>
    private EnemyStatus _enemyStatus;

    private void Start()
    {
        _enemyList = FindAnyObjectByType<EnemyList>();
        if (_bulletGroup == BulletGroup.Enemy)
        {
            _targetObject = GameObject.FindWithTag("Player");
        }// プレイヤーのオブジェクトを探す
        else
        {
            CheckTarget(_enemyList._targetList, _targetObject);
        }// 最初のtargetを探す
    }

    public void LateUpdate()
    {
        switch (_bulletGroup)
        {
            case BulletGroup.Enemy:
                if (CheckHit(_targetObject))
                {
                    PlayerStatus.Instance.PlayerDamage();
                    Destroy(this.gameObject);
                    Debug.Log("Hit");
                }//敵の球がプレイヤーに当たったらこのオブジェクトを破壊してライフを減らす
                break;
            case BulletGroup.Player:
                if (_enemyList._targetList != null)
                {
                    CheckTarget(_enemyList._targetList, _targetObject);
                    if (CheckHit(_targetObject))
                    {
                        _enemyStatus = _targetObject.GetComponent<EnemyStatus>();
                        _enemyStatus.EnemyDamege();
                        Destroy(this.gameObject);
                        Debug.Log("Hit");
                    }//プレイヤーの球が敵に当たったらこのオブジェクトを破壊して敵のライフを減らす
                }
                break;
        }
    }

    public bool CheckHit(GameObject target)
    {
        Transform targetTransform = target.transform;
        if(target == null)
        {
            return false;
        }
        if (Mathf.Abs(this.transform.position.x - target.transform.position.x) < (targetTransform.localScale.x + this.transform.localScale.x) / 2 &&
            Mathf.Abs(this.transform.position.y - target.transform.position.y) < (targetTransform.localScale.y + this.transform.localScale.y) / 2)
        {
            return true;
        }
        return false;
    }//ターゲットと当たったらtrueを返す当たり判定

    public void CheckTarget(List<GameObject> targetList, GameObject targetObject)
    {
        float targetDistance = float.MaxValue;
        foreach (GameObject target in targetList)
        {
            if(target != null)
            {
                float thisDistance = Vector3.Distance(target.transform.position, this.transform.position);
                if (targetDistance > thisDistance)
                {
                    targetDistance = thisDistance;
                    _targetObject = target;
                }
                else if (targetDistance == float.MaxValue)
                {
                    targetDistance = thisDistance;
                    _targetObject = target;
                }
                Debug.Log("ループせいこう");
            }
        }
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
