using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    //target
    Transform _target = null;

    Vector3 _dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletMove(_target);
    }
    public void init(Transform target)
    {
        _target= target;
        _dir = (_target.position - transform.position).normalized;
    }

    public void init(Vector3 dir)
    {
        _dir = dir;
    }

    void bulletMove(Transform target)
    {
        //target으로 이동 (유도)
        //transform.Translate((target.position - transform.position).normalized * Time.deltaTime * bulletSpeed);
        transform.Translate(_dir * Time.deltaTime * bulletSpeed);
    }
    public void remove()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //몬스터와 충돌 시 데미지 주고 삭제
    }
}
