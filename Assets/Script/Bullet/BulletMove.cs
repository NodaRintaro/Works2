using UnityEngine;

class BulletMove : BulletType
{ 
    [SerializeField] float _bulletPower = 1f;

    void Update()
    {
        if (_bulletGroup == BulletGroup.Player)
        {
            transform.Translate(_bulletPower, 0f, 0f);
        }
        else if (_bulletGroup == BulletGroup.Enemy)
        {
            transform.Translate(-_bulletPower, 0f, 0f);
        }
    }//Bulletの移動

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }//画面外に出たら破壊
}
