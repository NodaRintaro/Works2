using UnityEngine;

class BulletMove : MonoBehaviour
{ 
    [SerializeField,Header("移動速度")] float _bulletPower = 1f;
    [SerializeField,Header("移動方向")] bool _moveRight = true;
    void Update()
    {
        if (_moveRight)
            transform.Translate(_bulletPower, 0f, 0f);
        else
            transform.Translate(-_bulletPower, 0f, 0f);
    }//Bulletの移動

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }//画面外に出たら破壊
}
