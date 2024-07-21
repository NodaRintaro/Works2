﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private static PlayerStatus _instance = new PlayerStatus();
    public static PlayerStatus Instance => _instance;

    [SerializeField] private int _life = 5;

    public void Damage()
    {
        _life -= 1;
        if(_life == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
