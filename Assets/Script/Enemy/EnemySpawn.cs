using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float _timer;

    private Vector2 _thisPos;

    private bool _IsDead = false;
    
    private GameObject _checkTargetObject;

    [SerializeField,Header("出現させるオブジェクト")] GameObject _spawnObject;

    [SerializeField,Header("敵を出現させる間隔")]float _spawnTime;

    public void Start()
    {
        _thisPos = this.transform.position;

        Spawn(_checkTargetObject, _spawnObject);
    }

    public void Update()
    {
        if(_checkTargetObject == null)
            _timer += Time.deltaTime;

        if(_timer > _spawnTime)
        {
            if (_checkTargetObject == null)
            {
                Spawn(_checkTargetObject,_spawnObject);
            }
            _timer = 0;
        }
    }

    private void Spawn(GameObject target, GameObject spawnObj)
    {
        Instantiate(spawnObj, _thisPos,Quaternion.identity);
        target = spawnObj;
    }
}
