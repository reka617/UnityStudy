using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MonsterController : MonoBehaviour
{
    GameObject _player;
    GameObject _monster;
    Transform _hero;
    public int monsterCount = 0;
    List<Monster> mons = new List<Monster>();

    [SerializeField] GameUI _GameUI;

    void Start()
    {
        _player = GameObject.FindWithTag("Character");
        _hero = _player. GetComponent<Transform>();
        _monster = Resources.Load("Prefabs/Slime") as GameObject;
        makeMonsters();
    }

    public void makeMonsters()
    {
       
        for (int i = 0; i < 5; i++) 
        {
            GameObject mon = Instantiate(_monster, transform);
            mons.Add(mon.GetComponent<Monster>());
            monsterCount++;
        }

       foreach(Monster mon in mons) 
        {
            mon.init(this, _hero);
            
        }
        /*
        GameObject newMon = Instantiate(_monster);
        mons.Add(newMon.GetComponent<Monster>());

        Debug.Log("1st add count" + mons.Count);


        /*for (int i = 0; i < 10; i++)
        {
            Instantiate(_monster, transform);
        }
        Monster[] mons = GetComponentsInChildren<Monster>();

        Debug.Log("몬스터의 갯수 : " + mons.Length);

        foreach(Monster _mon in mons)
        {
            _mon.init();
        }*/
    }

    public void newMakeMonster()
    {
        bool isNew = true;
        foreach(Monster _mon in mons)
        {
            if(_mon.gameObject.activeSelf == false)
            {
                _mon.init(this, _hero);
                monsterCount++;
                isNew = false;
                break;
            }
        }
        if(isNew )
        {
            GameObject mon = Instantiate(_monster);
            mon.GetComponent<Monster>().init(this, _hero);
            mons.Add(mon.GetComponent<Monster>());
        }
    }

    public Transform selectMonster()
    {
        float distance = 0f;
        Transform target = null;
        foreach(Monster mon in mons)
        {
            if(distance <= Vector3.Distance(mon.transform.position,_hero.position) || target == null)
            {
                distance = Vector3.Distance(mon.transform.position,_hero.position);
                target = mon.transform;
            }
        }
        return target;
    }


   



    // Update is called once per frame
    void Update()
    {
        
    }
}
