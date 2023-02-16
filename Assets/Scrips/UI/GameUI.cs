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
    [SerializeField] Text _textExp;
    [SerializeField] SetSkillItems _setSkillItems;
    [SerializeField] CharacterController _player;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] Text _textUserName;
    public void OnButtonToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnButtonReplay()
    {
        SceneManager.LoadScene("Main");

    }

    public void OnExitButton()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void setChangeName(string _name)
    {
        _textUserName.text = _name;
    }

 
    
   

    public void ExpChange(int heroExp, int needExp)
    {
        float value = (float)heroExp / needExp;
        float min = 0;
        float max = 1;
        if (min > value) value = min;
        if (max <= value)
        {
            value -= max;
        }
        _expGauge.transform.localScale = new Vector3(value, 1, 1);
        _textLevel.text = "Lv." + _player._heroLv;
        _textExp.text = $"{value * 100}%";
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
