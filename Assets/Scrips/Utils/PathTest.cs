using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs ������ ���� �����ҋ� ���
        //PlayerPrefs.SetFloat("soundVolume", 0.5f);
        //PlayerPrefs.SetString("userName", "����");
        //PlayerPrefs.SetInt("userID", 955);

        float soundVolume = PlayerPrefs.GetFloat("defaultVolume", 1f);
        Debug.Log(soundVolume);

        string userName = PlayerPrefs.GetString("userName");
        Debug.Log(userName);

        int userID = PlayerPrefs.GetInt("userID");
        Debug.Log(userID);



        /*Debug.Log("dataPath : " + Application.dataPath);
        Debug.Log("persistentPath : " + Application.persistentDataPath); //persistentDataPath�� ����ϸ� ���� �ϳ��� �����Ͽ� �� ������ �����͵��� ����.

        Debug.Log(Directory.Exists(Application.persistentDataPath + "/datas"));
        
        if(!Directory.Exists(Application.persistentDataPath + "/user00"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + " /user00");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
