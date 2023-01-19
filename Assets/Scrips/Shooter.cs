using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet;

    [SerializeField]
    float _deg;

    [SerializeField]
    int bulletCount;

    [SerializeField]
    float degGap;

    [SerializeField]
    Transform target;
    
    Vector3 v3forward = new Vector3(1, 0, 0);
    Vector3 v3back = new Vector3(-1, 0, 0);
    Vector3 v3up = new Vector3(0, 1, 0);
    Vector3 v3down = new Vector3(0, -1, 0);
   
    // Start is called before the first frame update
    void Start()
    {
        /*float deg = _deg - 15;
        Vector3 v3custom = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
        GameObject tmp = Instantiate(_bullet );
        tmp.transform.position = transform.position;
        tmp.GetComponent<Bullet>().init(v3custom.normalized);

        float deg2 = _deg + 15;
        Vector3 v3custom2 = new Vector3(Mathf.Cos(deg2 * Mathf.Deg2Rad), Mathf.Sin(deg2 * Mathf.Deg2Rad), 0);
        GameObject tmp2 = Instantiate(_bullet);
        tmp2.transform.position = transform.position;
        tmp2.GetComponent<Bullet>().init(v3custom2.normalized);*/

        /*if (Input.GetKeyDown(KeyCode.V))
      {
          StartCoroutine(CoShot());
      }*/

          StartCoroutine(AnotherCoinfiniteShot());



    }



    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject tmp = Instantiate(_bullet);
                tmp.transform.position = transform.position;
                float deg = _deg + (i) * degGap;
                Vector3 v3custom = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
                tmp.GetComponent<Bullet>().init(v3custom.normalized);
            }
        }*/

      
    }

    

    IEnumerator CoShot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject tmp = Instantiate(_bullet);
            tmp.transform.position = transform.position;
            float deg = (_deg / bulletCount) * i;
            Vector3 v3custom = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
            tmp.GetComponent<Bullet>().init(v3custom.normalized);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CoInfiniteShot()
    {
        while(true)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject tmp = Instantiate(_bullet);
                tmp.transform.position = transform.position;
                float deg = _deg + (i) * degGap;
                Vector3 v3custom = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
                tmp.GetComponent<Bullet>().init(v3custom.normalized);
                //yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator AnotherCoinfiniteShot()// ÃßÀû¸ÖÆ¼¼¦
    {
        while (true)
        { 
            for (int i = 0; i < bulletCount; i++)
            {
                Vector3 v3tmp = target.position - transform.position;
                float radTmp = Mathf.Atan2(v3tmp.y, v3tmp.x) * Mathf.Rad2Deg;
                

                GameObject tmp = Instantiate(_bullet);
                tmp.transform.position = transform.position;
                float deg = i * (_deg / (bulletCount - 1)) + radTmp - _deg / 2f;
                Vector3 dir = new Vector3(Mathf.Cos(deg * Mathf.Deg2Rad), Mathf.Sin(deg * Mathf.Deg2Rad), 0);
                tmp.GetComponent<Bullet>().init(dir.normalized);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
