using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSound : MonoBehaviour
{
    Slider _slider;

    void Start()
    {
        _slider = transform.Find("Slider").GetComponent<Slider>();
        _slider.onValueChanged.AddListener(OnValueChanged);
    }

    public void OnValueChanged(float p)
    {
        Debug.Log($"{p} Value Changed");
    }
}
