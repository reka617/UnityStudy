using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    public void OnPauseRePlay()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }
    public void OnPauseToLobby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }
}
