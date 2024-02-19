using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float offsetX = 12f;
    [SerializeField] float offsetY = -8f;

    GameObject _target;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 offset = new Vector3(0, offsetY, offsetX);
      //  Debug.Log(transform.position);
        Debug.Log(_target);
        transform.position = _target.transform.position + offset;
        transform.LookAt(_target.transform);
    }
}
