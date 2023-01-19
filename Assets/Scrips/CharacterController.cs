using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

enum Anim
{
    Idle,
    Run,
    Attack
}
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpPower;

    [SerializeField]
    int hp;

    [SerializeField]
    int _attack;

    [SerializeField]
    GameObject _uiPanel;

    [SerializeField]
    MonsterController monCon;


    Animator _ani;
    SpriteRenderer _rend;
    Rigidbody2D _rb;
    GameObject _bullet;
    GameObject _bible;
    GameObject _circleBullet;
    GameObject _rotateBullet;

    public bool isJump;
    public bool isAttack;
    public bool isIdle;
    public bool isMove;
    bool isGameOver = false;

    int moveDirection; //1 : right 2: left 3: up

    int _circleBulletCount = 0;

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
            Transform target = monCon.selectMonster();
            GameObject tmp = Instantiate(_bullet);
            tmp.transform.position = transform.position;
            tmp.name = "Bullet";
            tmp.GetComponent<Bullet>().init(target);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(_bible,transform);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            float deg = 30f * _circleBulletCount;
            float y = Mathf.Sin(deg * Mathf.Deg2Rad);
            float x = Mathf.Cos(deg * Mathf.Deg2Rad);
            GameObject bullet = Instantiate(_circleBullet);
            bullet.transform.position = transform.position + new Vector3(x, y, 0) * 2;
            bullet.GetComponent<CircleBullet>().init(new Vector3(x, y, 0));
            _circleBulletCount++;
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
        Debug.Log("HP È¸º¹");
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
