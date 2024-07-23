using UnityEngine;

class BulletMove : MonoBehaviour
{ 
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] float _bulletPower = 1f;
    /// <summary>
    /// 移動方向
    /// </summary>
    [SerializeField] bool _moveRight = true;
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
