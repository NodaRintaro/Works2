using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAngle : MonoBehaviour
{
    [SerializeField, Header("Pointernのオブジェクト")] GameObject _pointer;

    /// <summary>
    /// 弾丸のオブジェクト
    /// </summary>
    [SerializeField] GameObject _bullet = null;

    Vector3 _mousePos;

    private Transform _transform;

    private float _radian;

    public void Start()
    {
        _transform = this.transform;
    }

    public void Update()
    {
        _mousePos = _pointer.transform.position;

        _radian = Mathf.Atan2(_mousePos.y,_mousePos.x);

        _transform.localRotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }

    public void OnFire()
    {
        Instantiate(_bullet, this.transform.position, Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1)));
        Debug.Log("生成!");
    }//右クリックされたらBulletを生成
}
