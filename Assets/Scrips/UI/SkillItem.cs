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

    public void init(stSkillData data)
    {
        _name.text = data.NAME + ", LV." + data.LV;
        _description.text = "DMG : " + data.DMG + ", RANGE : " + data.RANGE + ", BULLET : " + data.BULLET;
    }
}
