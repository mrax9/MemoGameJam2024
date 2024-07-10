using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Player : MonoBehaviour
{
    public float maxspeed = 3.0f;
    public float acceleration = 1.0f;
    public float deceleration = 2.0f;
    public float currentspeed;
    public GameObject BulletPrefab;
    public int playerid = 1;
    public float force = 1000;
    private Rigidbody2D _Rigid;
    private SpriteRenderer _Sr;
    private Skill skill;
    private string skillName;
    private bool isRight = true;
    private bool isCloaking = false;
    private bool isShielding = false;
    public bool isshocking = false;
    private float shockingTimeCount = 0;
    private Vector2 lastDir;
    void Start()
    {
        _Sr = GetComponent<SpriteRenderer>();
        _Rigid = GetComponent<Rigidbody2D>();
        currentspeed = 0.0f;
     
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontalplayer" + playerid);
        float y = Input.GetAxis("Verticalplayer" + playerid);
        Move(x, y);
        Flip(x);
        PlayerUseSkill(x, y, playerid);
        lastDir = _Rigid.velocity.normalized;
    }
    void Move(float x, float y)
    {
        Vector2 inputDirection = new Vector2(x, y).normalized;
        Vector2 accelerationVector = inputDirection * acceleration;
        if (inputDirection.magnitude > 0)
        {
            currentspeed = Mathf.MoveTowards(currentspeed, maxspeed, accelerationVector.magnitude * Time.deltaTime);
        }
        else
        {
            currentspeed = Mathf.MoveTowards(currentspeed, 0f, deceleration * Time.deltaTime);
        }
        Vector2 movement = inputDirection * currentspeed;
        if (isshocking && shockingTimeCount < 3)
        {
            shockingTimeCount += Time.deltaTime;
            movement = Vector2.zero;
        }
        else
        {
            shockingTimeCount = 0;
            isshocking = false;
        }
        _Rigid.velocity = movement;
    }

    void Flip(float x)
    {
        if (x < 0)
        {
            _Sr.flipX = true;
            isRight = false;
        }

        if (x > 0)
        {
            _Sr.flipX = false;
            isRight = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Player1" || tag == "Player2")
        {
            int id = int.Parse(tag.Substring(tag.Length - 1, 1));
            if (id != playerid)
            {
                _Rigid.AddForce(-lastDir * force, ForceMode2D.Force);
                isshocking = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetSkill(collision.gameObject);
    }
    void GetSkill(GameObject prof) 
    {
       bool profFlag = false;
        if (skill != null)
        {
            //Debug.Log("���ļ���δʹ�����");
            return;
        }
        string skillTag = prof.tag;
        switch (skillTag)
        {
            case "cloaking":
                skill = new Cloaking("cloaking", 2);
                skillName = "cloaking";
                profFlag = true;
                break;
            case "shield":
                skill = new Shield("shield", 2);
                skillName = "shield";
                profFlag = true;
                break;
            case "attack":
                skill = new Attack("attack",3) ;
                skillName = "attack";
                profFlag = true;
                break;
        }
        if (profFlag)
        {
            GameObject profGenerator = GameObject.FindGameObjectWithTag("propgenerator");
            ObjectGenerator objectGenerator = profGenerator.GetComponent<ObjectGenerator>();
            objectGenerator.generatedObjects.Remove(prof);
            Destroy(prof);
        }
    }
    void PlayerUseSkill(float x, float y,int playerid)
    {
        if (playerid == 1)
        {
            if (skill != null && Input.GetKeyUp(KeyCode.Space))
            {
                UseSkil(x, y, playerid);
            }
        }
        else
        {
            if (skill != null && Input.GetKeyUp(KeyCode.KeypadEnter))
            {
                UseSkil(x, y, playerid);
            }
        }
        EndSkill();
    }
    void UseSkil(float x, float y, int playerid)
    {
        switch (skillName)
        {
            case "cloaking":
                if (!((Cloaking)skill).isUsed)
                {
                    _Sr.color = new Color(_Sr.color.r, _Sr.color.g, _Sr.color.b, _Sr.color.a * 0.5f);
                    ((Cloaking)skill).isUsed = true;
                    isCloaking = true;
                }
                break;
            case "shield":
                if (!((Shield)skill).isUsed)
                {
                    ((Shield)skill).isUsed = true;
                    isShielding = true;
                }
                break;
            case "attack":
                GameObject bulletObj = Instantiate(BulletPrefab);
                bulletObj.transform.position = transform.position + (new Vector3(x, y)).normalized * 1;
                Bullet bullet = bulletObj.GetComponent<Bullet>();
                if (x == 0 && y == 0)
                {
                    if (isRight)
                    {
                        bullet.BasicSet(Vector3.right,playerid);
                    }
                    else
                    {
                        bullet.BasicSet(Vector3.left, playerid);
                    }
                }
                else
                {
                    bullet.BasicSet((new Vector3(x, y)).normalized, playerid);
                }
                ((Attack)skill).times -= 1;
                break;
        }

    }
    void EndSkill()
    {
        if (skillName != null)
        {
            if (skillName == "cloaking" && ((Cloaking)skill).isUsed)
            {
                if (((Cloaking)skill).duration > 0)
                    ((Cloaking)skill).duration -= Time.deltaTime;
                else
                {
                    skill = null;
                    skillName = null;
                    _Sr.color = new Color(_Sr.color.r, _Sr.color.g, _Sr.color.b, _Sr.color.a * 2);
                    isCloaking = false;
                }
            }
            if (skillName == "shield" && ((Shield)skill).isUsed)
            {
                if (((Shield)skill).duration > 0)
                    ((Shield)skill).duration -= Time.deltaTime;
                else
                {
                    skill = null;
                    skillName = null;
                    isShielding = false;
                }
            }
            if ((skillName == "attack"))
            {
                if (((Attack)skill).times <= 0)
                {
                    skill = null;
                    skillName = null;
                }
            }
        }
    }

}
