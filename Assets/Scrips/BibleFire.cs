using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleFire : MonoBehaviour
{

    int _level;
    GameObject _bible;

    private void Awake()
    {
        _bible = Resources.Load("Prefabs/Bible") as GameObject;
    }

    public void Init(int level)
    {
        _level = level;
        //기존 투사체 전부 삭제
        StartCoroutine(CoMakeBible());
    }

    IEnumerator CoMakeBible()
    {
        int count = 0;
        while(count < _level)
        {
            Instantiate(_bible, transform);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }
}
