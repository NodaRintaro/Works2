using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField] private GameObject _pointerObj;

    private Vector2 _mousePos;

    private Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        _mousePos = _camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));

        _pointerObj.transform.position = _mousePos;
    }
}
