using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int _enemyLife = 3;

    public void EnemyLife()
    {
        _enemyLife -= 1;
        if (_enemyLife == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
