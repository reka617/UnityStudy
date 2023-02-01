using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Image _expGauge;
    [SerializeField] Text _textLevel;
    [SerializeField] SetSkillItems _setSkillItems;
    public void OnButtonToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnButtonReplay()
    {
        SceneManager.LoadScene("Main");

    }
    
    public void ExpChange(float value)
    {
        float min = 0;
        float max = 1;
        int levelCount = 0;
        if (min > value) value = min;
        if (max <= value)
        {
            value -= max;
            levelCount++;
            _setSkillItems.ShowSkillPanel();
        }
        _textLevel.text = "Lv." + levelCount;
        _expGauge.transform.localScale = new Vector3(value, 1, 1);
        
    }

    

    private void Update()
    {
        //_expGauge.transform.localScale += new Vector3(Time.deltaTime, 0, 0);
        //if(_expGauge.transform.localScale.x >= 1)
        //{
        //    _expGauge.transform.localScale = new Vector3(0, 1, 1);
        //}
    }
}
