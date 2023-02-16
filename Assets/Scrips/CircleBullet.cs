using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : MonoBehaviour
{
    [SerializeField]
    float _speed;
    Vector3 _target;

    float lifeTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void init(Vector3 target)
    {
        _target = target;
    }

    public void remove()
    {
        Destroy(gameObject);
    }

    void circlebulletMove(Vector3 target)
    {
        transform.Translate(target * Time.deltaTime * _speed);
    }

    // Update is called once per frame
    void Update()
    {
        circlebulletMove(_target);
    }
}
