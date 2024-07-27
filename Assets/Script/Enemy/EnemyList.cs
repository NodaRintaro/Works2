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
    /// �^�[�Q�b�g�̃��X�g
    /// </summary>
    public List<GameObject> _targetList;

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
    }//���s����Enemy���擾

    private void ChangeTag (string newTag, GameObject changeTagObject)
    {
        changeTagObject.tag = newTag;
    }//�����ɓ���Object��List��Add�������Ȃ��悤�ɑ΍�Ƃ���Add����Object��Tag��������
}