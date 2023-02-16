using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using static CsvController;

public enum EskillType
{
    none,
    bibleShot,
    homingShot,
    dagger,
    MAX
}
public class CsvController : MonoBehaviour
{

    public List<stHeroData> lstHero = new List<stHeroData>();
    public List<stSkillData> lstSKillData = new List<stSkillData>();
    public List<stLevelData> lstLevelData = new List<stLevelData>();

    void ReadSkillData()
    {
        string path = Application.dataPath + "/Resources/Datas/SkillData.csv";
        if (File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0])) continue;

                    stSkillData tempData = new stSkillData();
                    tempData.INDEX = int.Parse(values[0]);
                    tempData.LV = int.Parse(values[1]);
                    tempData.ETYPE = (EskillType)Enum.Parse(typeof(EskillType), values[2]);
                    tempData.DMG = int.Parse(values[3]);
                    tempData.BULLET = int.Parse(values[4]);
                    tempData.RANGE = float.Parse(values[5]);

                    lstSKillData.Add(tempData);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //ReadFile();
        ReadSkillData();
        //WriteFile(); 
        ReadLevelData();
    }

    void ReadFile()
    {
        
        string path = Application.dataPath + "/Resources/Datas/Source.csv";

        if (File.Exists(path))
        {
            
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0])) continue;

                    stHeroData tempData = new stHeroData();
                    tempData.INDEX = int.Parse(values[0]);
                    tempData.NAME = values[1];
                    tempData.EXP = int.Parse(values[2]);
                    tempData.LEVEL = int.Parse(values[3]);
                    tempData.MOVESPEED = float.Parse(values[4]);
                    tempData.ATTACKPOWER = int.Parse(values[5]);

                    lstHero.Add(tempData);

                    //int j = 0;
                    // foreach(string data in values)
                    // {
                    //     Debug.Log(i + "행의 " + j +"번째 데이터는" + data + "입니다.");
                    //     j++;
                    // }
                }
                /*source= sr.ReadToEnd();  
                Debug.Log(source);*/
            }
        }
    }

    void ReadLevelData()
    {
        string path = Application.dataPath + "/Resources/Datas/LevelData.csv";
        if (File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0])) continue;

                    stLevelData tempData = new stLevelData();
                    tempData.INDEX = int.Parse(values[0]);
                    tempData.LV = int.Parse(values[1]);
                    tempData.SUMEXP = int.Parse(values[2]);
                    tempData.EXP = int.Parse(values[3]);

                    lstLevelData.Add(tempData);
                }
                //foreach (stLevelData data in lstLevelData)
                //{
                //    Debug.Log($"data : {data.LV}, {data.SUMEXP}, {data.EXP}");
                //}
            }
        }
    }

    void WriteFile()
    {
        string fileName = "saveFile" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";
        
        string delimiter = ",";

        List<string[]> lists = new List<string[]>();

        string[] datas = new string[] { "Name", "Time", "Stage", "Exp" };
        lists.Add(datas);
        string[] value1 = new string[] { "p1", DateTime.Now.ToString(), "15", "54534" };
        lists.Add(value1);
        string[] value2 = new string[] { "p2", DateTime.Now.ToString(), "5", "544" };
        lists.Add(value2);

        string[][] ouTPuts = lists.ToArray();
        StringBuilder sb = new StringBuilder();
        for (int  i = 0; i< ouTPuts.Length; i++) 
        {
            sb.AppendLine(string.Join(delimiter, ouTPuts[i]));
        }

        string filepath = Application.dataPath + "/Resources/Datas/" + fileName;

        using (StreamWriter sw = File.CreateText(filepath))
        {
            sw.Write(sb);
        }
    }

    public struct stSkillData
    {
        public int INDEX;
        public EskillType ETYPE;
        public int LV;
        public int DMG;
        public int BULLET;
        public float RANGE;
    }


    public struct stHeroData
    {
        public int INDEX;
        public string NAME;
        public int EXP;
        public int LEVEL;
        public float MOVESPEED;
        public int ATTACKPOWER;
    }

    public struct stLevelData
    {
        public int INDEX;
        public int LV;
        public int SUMEXP;
        public int EXP;
    }

}
