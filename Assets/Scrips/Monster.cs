using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

enum slimeAnim
{
    slime_Idle,
    slime_Die
}

public class Monster : MonoBehaviour
{
    MonsterController _MC;
    CharacterController _CC;
   

    Transform _hero;
    float _speed;
    [SerializeField] int _hp;

    [SerializeField] Image _slimeHpBar;


    Animator _ani;
    SpriteRenderer _render;
    bool isHitted = false;
    bool isRun = false;
    bool isDie = false;

    int MAXHP;
    

    float _runTimer = 0f; 
    float _colorTimer = 0f;

    void Start()
    {
        _ani= GetComponent<Animator>();
        _render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!isDie)
        {
            Live();
            Move();
        }
            
        ChangeHitColor();
        Run();
    }

    public void init(MonsterController MC, Transform hero)
    {
        isDie = false;
        _hero= hero;
        _MC = MC;
        _speed = 1;
        MAXHP = 20;
        _hp = MAXHP;
        _slimeHpBar.transform.localScale = new Vector3(1, 1, 1);

        if (_MC.monsterCount > 3)
        {
            MAXHP += 20;
            _hp = MAXHP;

            Debug.Log("몬스터의 체력이 증가하였습니다.");
        }
        gameObject.SetActive(true);
        Vector3 ranPos = _hero.position + new Vector3(Random.Range(0, 1f), Random.Range(0, 1f)).normalized * 2;
        transform.position = ranPos;
        Debug.Log("몬스터 초기화를 호출합니다.");
    }

    void Live()
    {
        isDie = false;
        _ani.Play(slimeAnim.slime_Idle.ToString());
    }

    void Move()
    {
        Vector2 direction = _hero.position - transform.position; 
        
        if (isRun == true)
            transform.Translate(-direction.normalized * Time.deltaTime * _speed);
        else
            transform.Translate(direction.normalized * Time.deltaTime * _speed);


    }

    void ChangeHitColor()
    {
        if (isHitted == true)
        {
            _colorTimer += Time.deltaTime;
            _render.color = Color.red;
            if (_colorTimer > 0.1f)
            {
                isHitted = false;
                _render.color = Color.white;
                _colorTimer = 0f;
            }
        }
    }

    void Run()
    {
        if (isRun == true)
        {
            _runTimer += Time.deltaTime;
            if (_runTimer > 0.5f)
            {
                isRun = false;
                _runTimer = 0f;
            }
        }
    }

    void dieEnd()
    {
        gameObject.SetActive(false);
        _MC.newMakeMonster();
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //int attack = collision.gameObject.GetComponent<CharacterController>().getAttack();
            //onHitted(attack);
            collision.gameObject.GetComponent<CharacterController>().hitted();
        }
        if(collision.gameObject.name == "Bullet")
        {
            int BD = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            if(_hp>0)
            {
                onHitted(BD);
            }
            SlimeHpDown();
            collision.gameObject.GetComponent<BulletRemove>().remove();

        }
        if (collision.gameObject.name == "Bible")
        {
            int BD = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            if (_hp > 0)
            {
                onHitted(BD);
            }
            SlimeHpDown();
            collision.gameObject.GetComponent<BulletRemove>().remove();

        }
        if (collision.gameObject.name == "Dagger")
        {
            int BD = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            if (_hp > 0)
            {
                onHitted(BD);
            }
            SlimeHpDown();
            collision.gameObject.GetComponent<BulletRemove>().remove();

        }
    }
    public void SlimeHpDown()
    {
        SlimeHpChange((float)(_hp) / MAXHP);
    }

    public void SlimeHpChange(float value)
    {
        if (value < 0) value = 0;
        _slimeHpBar.transform.localScale = new Vector3(value, 1, 1);
    }

    void onHitted(int hitPower)
    {
        _CC = _hero.gameObject.GetComponent<CharacterController>();
        _hp -= hitPower;
        isHitted = true;
        isRun = true;
        if (_hp <= 0)
        {
            _CC.heroExpUP();
            isDie = true;
            if(isDie)
            {

                _ani.Play(slimeAnim.slime_Die.ToString());
                
            }
            
            
        }
    }

  
   
}


