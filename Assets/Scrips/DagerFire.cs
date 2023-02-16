using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagerFire : MonoBehaviour
{
    int _level;
    public bool isCoroutineing;
    GameObject _dager;
    // Start is called before the first frame update

    public void Awake()
    {
        _dager = Resources.Load("Prefabs/CircleBullet") as GameObject;
    }




    public void Init(int level)
    {
        _level= level;
        StartCoroutine(CoMakeDager());
    }

    IEnumerator CoMakeDager()
    {
        int _dagerCount = 3;
        int _count = 0;

        while (_count < _level)
        {
            for (int i = 0; i < _dagerCount; i++)
            {
                float deg = 15f * i;
                float y = Mathf.Sin(deg * Mathf.Deg2Rad);
                float x = Mathf.Cos(deg * Mathf.Deg2Rad);
                GameObject bullet = Instantiate(_dager);
                bullet.transform.position = transform.position + new Vector3(x, y, 0);
                bullet.name = "Dagger";
                bullet.GetComponent<CircleBullet>().init(new Vector3(x, y, 0));
            }
            yield return new WaitForSeconds(0.5f);
        }

        //if (_count < _level)
        //{
        //    _count++;
        //    _dagerCount++;
        //}
    }

}
   

