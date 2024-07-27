using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private static PlayerStatus _instance = new PlayerStatus();
    public static PlayerStatus Instance => _instance;

    [SerializeField] int _life = 5;

    private GameObject _player;
    public void PlayerDamage()
    {
        _life -= 1;
        if(_life <= 0)
        {
            _player = GameObject.Find("Player");
            Destroy(_player);
        }
    }
}
