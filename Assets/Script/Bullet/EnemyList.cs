using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletCollider;

[System.Serializable]
public class EnemyList
{
    private static EnemyList _instance = new EnemyList();
    public static EnemyList Instance => _instance;
    /// <summary>
    /// ターゲットのリスト
    /// </summary>
    public List<GameObject> _targetList = new List<GameObject>();
    public void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            if (GameObject.FindWithTag("Enemy") != null)
            {
                _targetList.Add(GameObject.FindWithTag("Enemy"));
            }
            else
            {
                break;
            }
        }
    }
}
