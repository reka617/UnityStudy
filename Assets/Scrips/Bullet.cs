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
        //target���� �̵� (����)
        //transform.Translate((target.position - transform.position).normalized * Time.deltaTime * bulletSpeed);
        transform.Translate(_dir * Time.deltaTime * bulletSpeed);
    }
    public void remove()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���Ϳ� �浹 �� ������ �ְ� ����
    }
}
