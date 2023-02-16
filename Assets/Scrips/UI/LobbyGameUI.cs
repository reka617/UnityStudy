using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyGameUI : MonoBehaviour
{
    [SerializeField] GameObject IDCheckPanel;
    [SerializeField] TMP_InputField _text;

    public void OnLobbyToIDCheck()
    {
        IDCheckPanel.SetActive(true);
    }

    public void OnIDChekcToLobby()
    {
        IDCheckPanel.SetActive(false);
    }

    public void OnChangedValue()
    {
        PlayerPrefs.SetString("Name",_text.text);
    }

    


    private void Update()
    {
    }

}
