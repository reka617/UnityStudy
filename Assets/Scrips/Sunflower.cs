using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sunflower : MonoBehaviour
{
    int _hp = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
           collision.gameObject.GetComponent<CharacterController>().HealHP(_hp);
           Delete();
        }
    }

   

    void Delete()
    {
        gameObject.SetActive(false);
    }
}
