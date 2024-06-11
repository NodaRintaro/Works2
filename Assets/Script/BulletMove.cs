using System.Collections;using System.Collections.Generic;using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float _bulletPower = 1f;
    void Update()
    {
        transform.Translate(_bulletPower, 0f, 0f);
    }//Bulletの移動

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }//画面外に出たら破壊
}
