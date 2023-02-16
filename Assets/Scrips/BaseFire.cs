using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseFire : MonoBehaviour
{
    int _level;
    GameObject _bullet;
    MonsterController _mc;
    private void Awake()
    {
        _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
    }

    public void Init(MonsterController mc)
    {
        _mc = mc;
        StartCoroutine(CoMakeBaseBullet());
    }

    IEnumerator CoMakeBaseBullet()
    {
        for (int i = 0; i < 1; i++)
        {
            Transform target = _mc.selectMonster();
            if(target == null) 
            {
                yield return new WaitForSeconds(1);
                continue;
            }
            GameObject tmp = Instantiate(_bullet);
            tmp.transform.position = transform.position;
            tmp.name = "Bullet";
            tmp.GetComponent<Bullet>().init(target);
        }
        yield return new WaitForSeconds(0.5f);
    }
}
