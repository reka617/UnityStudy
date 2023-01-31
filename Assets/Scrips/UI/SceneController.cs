using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnButtonToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void OnButtonReplay()
    {
        SceneManager.LoadScene("Main");

    }
}
