using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    [SerializeField]
    float _speed;

    float _time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*void init(Transform hero)
    {
        _hero = hero;
    }*/

    void biblemove()
    {
        _time += Time.deltaTime;   
        transform.localPosition =  new Vector3(Mathf.Cos(_time),Mathf.Sin(_time), 0) * _speed;
       
    }

    // Update is called once per frame
    void Update()
    {
        biblemove();
    }
}
