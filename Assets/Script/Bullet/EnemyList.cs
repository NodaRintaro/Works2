using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletCollider;

[System.Serializable]
public class EnemyList:MonoBehaviour
{
    private static EnemyList _instance = new EnemyList();
    public static EnemyList Instance => _instance;
    /// <summary>
    /// ターゲットのリスト
    /// </summary>
    public List<GameObject> _targetList = new List<GameObject>();

    private GameObject _target;

    private string _newTagName = "EnemyInList";
    public void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            if (GameObject.FindWithTag("Enemy") != null)
            {
                _target = GameObject.FindWithTag("Enemy");
                _targetList.Add(_target);
                ChangeTag(_newTagName, _target);
                Debug.Log("Add");
            }
            else
            {
                break;
            }
        }
    }

    private void ChangeTag (string newTag, GameObject changeTagObject)
    {
        changeTagObject.tag = newTag;
    }
}
