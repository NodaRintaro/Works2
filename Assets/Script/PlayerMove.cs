using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̓������x
    /// </summary>
    [SerializeField] float _movePower = 1f;

    /// <summary>
    /// �v���C���[�̃W�����v��
    /// </summary>
    [SerializeField] float _jumpPower = 1f;

    /// <summary>
    /// �e�ۂ̃I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject _bullet = null;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-_movePower, 0f, 0f);
            Debug.Log("��");
        }//�L�[�̓��͂�����΍��֐i��
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_movePower, 0f, 0f);
            Debug.Log("�E");
        }//�L�[�̓��͂�����ΉE�֐i��
    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }

    public void OnFire(InputAction.CallbackContext context)
    {

    }
}
