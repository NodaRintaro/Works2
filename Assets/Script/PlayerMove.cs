using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Vector2 _dir = default;

    Transform _myTransform;

    void Update()
    {
        _myTransform = this.transform;
        float x += 1;
        float y = 0;
        _dir = new Vector2(x, y);
        _myTransform.position = _dir;
    }
}
