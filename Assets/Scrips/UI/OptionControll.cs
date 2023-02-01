using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionControll : MonoBehaviour
{
    [SerializeField]
    Toggle _toggle;

    [SerializeField]
    Slider _slider;

    [SerializeField]
    InputField _inputField;

    private void Start()
    {
        _toggle.isOn = false;       
    }

    public void OnToggleChange()
    {
        //Debug.Log("Toggle Change to : " + _toggle.isOn);

    }
    
    public void OnSliderValueChange()
    {
        //Debug.Log("slider value to : " + _slider.value);
    }

    public void OnInputfieldChange()
    {
        Debug.Log("inputField text : " + _inputField.text);
    }

    void Update()
    {
        _slider.value += Time.deltaTime;
        if(_slider.value >= 1) 
        {
            _slider.value = 0;
        }
    }
}
