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
    [SerializeField] CharacterController _hero;

    List<GameObject> lstItems= new List<GameObject>();
    
    public void ShowSkillPanel()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        for (int i = 1; i < (int)EskillType.MAX; i++)
        {
            foreach (stSkillData data in _controller.lstSKillData)
            {
                if (data.ETYPE != (EskillType)i) continue;
                if(_hero.dicSkills.ContainsKey(data.ETYPE) == true)
                {
                    if(data.LV == _hero.dicSkills[data.ETYPE] + 1)
                    {
                        GameObject tmp = Instantiate(_item, _content);
                        tmp.GetComponent<SkillItem>().init(data, this);
                        lstItems.Add(tmp);
                    }
                }
                else
                {
                    if(data.LV == 1)
                    {
                        GameObject tmp = Instantiate(_item, _content);
                        tmp.GetComponent<SkillItem>().init(data, this);
                        lstItems.Add(tmp);
                    }
                }
                
            }
        }
    }

    public void characterLvup(stSkillData data)
    {
        _hero.getSkill(data);
        gameObject.SetActive(false);
        foreach (GameObject tmp in lstItems)
        {
            Destroy(tmp);
        }
        lstItems.Clear();
        Time.timeScale= 1;
    }


    private void Start()
    {

    }
}
