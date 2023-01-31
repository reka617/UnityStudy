using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    public void OnButtonGameStart()
    {
        SceneManager.LoadScene("Main");
    }
      

}
