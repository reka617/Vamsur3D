using System.Collections;
using UnityEngine;

public class LightBlick : MonoBehaviour
{
    [SerializeField] Light _light;
    [SerializeField] float _speed = 0.5f;
    float _timer = 0;
    int _i = 1;

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > 3)
        {
            _i *= -1;
            _timer = 0;
        }
        _light.intensity += Time.deltaTime * (float)_i * _speed;
    }


}
