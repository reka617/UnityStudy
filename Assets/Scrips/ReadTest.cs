using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTest : MonoBehaviour
{
    [SerializeField] CsvController _controller;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_controller.lstHero[0].NAME);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
