using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs 간단한 정보 저장할떄 사용
        //PlayerPrefs.SetFloat("soundVolume", 0.5f);
        //PlayerPrefs.SetString("userName", "영웅");
        //PlayerPrefs.SetInt("userID", 955);

        float soundVolume = PlayerPrefs.GetFloat("defaultVolume", 1f);
        Debug.Log(soundVolume);

        string userName = PlayerPrefs.GetString("userName");
        Debug.Log(userName);

        int userID = PlayerPrefs.GetInt("userID");
        Debug.Log(userID);



        /*Debug.Log("dataPath : " + Application.dataPath);
        Debug.Log("persistentPath : " + Application.persistentDataPath); //persistentDataPath를 사용하면 폴더 하나를 생성하여 그 폴더에 데이터들을 넣음.

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
