using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BulletType : MonoBehaviour
{
    [SerializeField]public BulletGroup _bulletGroup;

    public enum BulletGroup
    {
        Enemy,
        Player
    }
}
