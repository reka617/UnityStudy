using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static CsvController;

public class SetSkillItems : MonoBehaviour
{
    [SerializeField] CsvController _controller;
    [SerializeField] GameObject _item;
    [SerializeField] Transform _content;
    public void ShowSkillPanel()
    {
        gameObject.SetActive(true);
        foreach(stSkillData data in _controller.lstSKillData)
        {
            GameObject tmp = Instantiate(_item, _content); 
            tmp.GetComponent<SkillItem>().init(data);
        }
    }


    private void Start()
    {

    }
}
