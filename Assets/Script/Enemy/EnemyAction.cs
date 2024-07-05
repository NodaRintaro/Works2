using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    /// <summary>
    /// �^�[�Q�b�g�ƂȂ�v���C���[�̃I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject _targetObject = null;
    /// <summary>
    /// �e�ۂ̃I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject _bullet = null;
    /// <summary>
    /// �^�[�Q�b�g�ɂނ��Ĕ��C���J�n���鋗��
    /// </summary>
    [SerializeField] float _rangeDistance = 5;
    /// <summary>
    /// �v���C���[�Ƃ̋���
    /// </summary>
    private float _distance;
    /// <summary>
    /// ���̃I�u�W�F�N�g�̈ʒu
    /// </summary>
    private Vector2 _thisObjectPosition;
    /// <summary>
    /// �^�[�Q�b�g�ƂȂ�v���C���[�̈ʒu
    /// </summary>
    private Vector2 _targetObjectPosition;
    /// <summary>
    /// Bullet�̔��˃C���^�[�o��
    /// </summary>
    private float _fireDistance = 1;
    /// <summary>
    /// �^�C�}�[
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
    }//�v���C���[���˒������ɓ������甭�C���J�n���鏈��
}
