using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CsvController;

public class SkillItem : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Text _name;
    [SerializeField] Text _description;

    SetSkillItems _parent;
    stSkillData _data;

    public void init(stSkillData data, SetSkillItems parent)
    {
        _data = data;
        _parent = parent;
        _name.text = data.ETYPE + ", LV." + data.LV;
        _description.text = "DMG : " + data.DMG + ", RANGE : " + data.RANGE + ", BULLET : " + data.BULLET;
    }

    public void Onselected()
    {
        _parent.characterLvup(_data);
        _parent.gameObject.SetActive(false);
    }
}
