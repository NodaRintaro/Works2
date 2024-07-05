using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float _bulletPower = 1f;

    [SerializeField] BulletType _bulletType;

    void Update()
    {
        transform.Translate(_bulletPower, 0f, 0f);
    }//Bulletの移動

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }//画面外に出たら破壊

    enum BulletType
    {
        EnemyBullet,
        PlayerBullet
    }
}
