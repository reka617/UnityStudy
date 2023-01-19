using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBullet : MonoBehaviour
{
    [SerializeField]
    float _speed;
    Vector3 _lastPos;
    float _timer = 0f;
    Vector3 _target;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    public void init(Vector3 target)
    {
        _lastPos = transform.position;
        _target = (target - _lastPos).normalized;
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _lastPos += _target * Time.deltaTime * _speed;
        transform.position = new Vector3(Mathf.Cos(_timer), Mathf.Sin(_timer), 0) * 3;
        transform.position += _lastPos;
    }
}
