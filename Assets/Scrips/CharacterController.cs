using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static CsvController;

enum Anim
{
    Idle,
    Run,
    Attack
}
public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] int hp;
    [SerializeField] int _attack;
    [SerializeField] int _heroExp;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] MonsterController monCon;
    [SerializeField] GameUI _GameUI;
    [SerializeField] SetSkillItems _skillPanel;
    

    [SerializeField] CsvController _leveldata;

    public Dictionary<EskillType, int> dicSkills = new Dictionary<EskillType, int>();


    Animator _ani;
    SpriteRenderer _rend;
    Rigidbody2D _rb;
    GameObject _bullet;
    GameObject _bible;
    GameObject _circleBullet;
    GameObject _rotateBullet;

    DagerFire df;
    BibleFire biblef;
    BaseFire basef;

    public bool isJump;
    public bool isAttack;
    public bool isIdle;
    public bool isMove;
    bool isGameOver = false;

    int moveDirection; //1 : right 2: left 3: up

    

    int _heroSumExp = 0;
    int _needExp = 100;
    public int _heroLv = 1;

    string _heroName;

    private void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        _rend = gameObject.GetComponent<SpriteRenderer>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _uiPanel.SetActive(false);
        _bullet = Resources.Load("Prefabs/Bullet") as GameObject;
        _bible = Resources.Load("Prefabs/Bible") as GameObject;
        _circleBullet = Resources.Load("Prefabs/CircleBullet") as GameObject;
        _rotateBullet = Resources.Load("Prefabs/RotateBullet") as GameObject;

        
        /* float sign = Mathf.Sin(30);
         float radSign = 30 * Mathf.Deg2Rad;
         float resultSign = Mathf.Sin(radSign);
         Debug.Log("sign value : " + sign + ", radSign value : " + resultSign);*/
    }
    void Update()
    {
        if (isGameOver) return;
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.GetComponent<BaseFire>() == null)
            {
                basef = gameObject.AddComponent<BaseFire>();
                basef.Init(monCon);
            }
            else
            {
                basef = gameObject.GetComponent<BaseFire>();
                basef.Init(monCon);
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (gameObject.GetComponent<BibleFire>() == null)
            {
                BibleFire bf = gameObject.AddComponent<BibleFire>();
                bf.Init(1);

            }

        }

        if (Input.GetKeyDown(KeyCode.F))//단검
        {
        
           
            

        }
        if(Input.GetKeyDown(KeyCode.G)) 
        {
            Transform target = monCon.selectMonster();
            GameObject bullet = Instantiate(_rotateBullet);
            bullet.transform.position = transform.position;
            bullet.GetComponent<RotateBullet>().init(target.position);
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown("x"))
        {
            if(!isJump)
            {
                isJump = true;
                _rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    void Move()
    {
        Vector2 v2 = Vector2.zero;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rend.flipX = false;
            _ani.Play(Anim.Run.ToString());
            v2 += Vector2.left * Time.deltaTime * speed;
            transform.Translate(v2);
            isIdle = false;
            isMove = true;


        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rend.flipX = true;
            _ani.Play(Anim.Run.ToString());
            v2 += Vector2.right * Time.deltaTime * speed;
            transform.Translate(v2);
            isIdle = false;
            isMove = true;
        }
        if (isIdle)
        {
            _ani.Play(Anim.Idle.ToString());
        }

        
        Jump();
        Attack();
    }

    void Attack()
    {
        if (Input.GetKey("a"))
        {
            if (!isAttack)
            {
                isAttack = true;
                isIdle = false;
                _ani.Play(Anim.Attack.ToString());
            }
        }


        else
        {
            isAttack = false;
            isIdle = true;
            isMove = true;
        }

        setHeroName();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isJump = false;
        }
        if (collision.gameObject.tag.Equals("Object"))
        {
            isJump = false;
        }
        if (collision.gameObject.tag.Equals("UnderGround"))
        {
            ResetPosition();
        }
        if (collision.gameObject.name.Equals("Chest"))
        {
            Box box = collision.gameObject.GetComponent<Box>();
            if (box != null)
            {
               box.BoxOpen();
            }
        } 
    }

    void ResetPosition()
    {
        transform.position = new Vector3((float)-8.917252, (float)-3.653096, 0);
    }
    public void HealHP(int _hp)
    {
        hp += _hp;
        Debug.Log("HP 회복");
    }

    public void getSkill(stSkillData data)
    {

        if (dicSkills.ContainsKey(data.ETYPE) == false) // 스킬 안배움
        {
            dicSkills.Add(data.ETYPE, data.LV);
            switch (data.ETYPE)
            {
                case EskillType.dagger:
                    {
                        if (gameObject.GetComponent<DagerFire>() == null)
                        {
                            df = gameObject.AddComponent<DagerFire>();
                            df.Init(1);
                        }
                    }
                    break;
                case EskillType.homingShot:
                    {

                    }
                    break;
                case EskillType.bibleShot:
                    {
                        if (gameObject.GetComponent<BibleFire>() == null)
                        {
                            BibleFire bf = gameObject.AddComponent<BibleFire>();
                            bf.Init(1);
                        }
                    }
                    break;


            }
        }
        else // 스킬배움
        {
            dicSkills[data.ETYPE] = data.LV;
            switch (data.ETYPE)
            {
                case EskillType.dagger:
                    {
                        if (gameObject.GetComponent<DagerFire>() != null)
                        {
                            df = gameObject.GetComponent<DagerFire>();
                            if (!df.isCoroutineing)
                            {
                                df.Init(1);
                            }
                        }

                    }
                    break;
                case EskillType.homingShot:
                    {

                    }
                    break;
                case EskillType.bibleShot:
                    {
                        if (gameObject.GetComponent<BibleFire>() != null)
                        {
                            biblef = gameObject.GetComponent<BibleFire>();
                            biblef.Init(1);
                        }
                    }
                    break;



            }

        }
        
    }

    void setLevelUpExp()
    {
        int nowNeedExp = 0;
        int nextNeedExp = 0;

        _heroLv++;
        foreach (stLevelData data in _leveldata.lstLevelData)
        {
            if (data.LV == _heroLv) nowNeedExp = data.SUMEXP;
            if (data.LV == _heroLv + 1) nextNeedExp = data.SUMEXP;
        }
        
        _needExp = nextNeedExp - nowNeedExp;
        _heroExp = _heroSumExp - nowNeedExp;
    }

    public void heroExpUP()
    {
        _heroExp += 60;
        _heroSumExp += 60;
        if (_heroExp >= _needExp)
        {
            setLevelUpExp();
            _skillPanel.ShowSkillPanel();
        }
        _GameUI.ExpChange(_heroExp, _needExp);
    }

    public void setHeroName()
    {
        _heroName = PlayerPrefs.GetString("Name");
        _GameUI.setChangeName(_heroName);
    }

    public int getAttack()
    {
        return _attack;
    }

    public void hitted()
    {
        if (hp <= 0) return;
        hp -= 5;
        if (hp <= 0)
        {
            isGameOver = true;
            _uiPanel.SetActive(true);
        }
    }
    

}
