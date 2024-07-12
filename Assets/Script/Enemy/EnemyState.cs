using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private static EnemyState _instance = new EnemyState();
    public static EnemyState Instance => _instance;

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
