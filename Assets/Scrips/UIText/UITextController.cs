using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextController : MonoBehaviour
{
    [SerializeField]
    Image _coolTime;
    [SerializeField]
    Image _image;
    [SerializeField]
    Text _text;
    [SerializeField]
    Text _userName;

    void Start()
    {
       
    }

    public void OnButtonDownPLAY()
    {
        _image.fillAmount = 0.3f;
        _coolTime.fillAmount = 0.7f;
        _text.text = "Lv.105";
        _userName.text = "PSJ";
    }
    
    public void OnButtonDownRESET()
    {
        _image.fillAmount = 0f;
        _coolTime.fillAmount = 1f;
        _text.text = "Lv.00";
        _userName.text = "UserName";
    }

    public void OnPointerDown()
    {
        Debug.Log("OnPointerDown");
    }

    public void OnOptionClick()
    {
        Debug.Log("OnOptionClick");
    }
}
