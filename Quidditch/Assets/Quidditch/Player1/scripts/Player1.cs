using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxspeed = 3.0f;
    public float acceleration = 1.0f;
    public float deceleration = 2.0f;
    public float currentspeed;
    public GameObject BulletPrefab;
    public int playerid = 1;
    private Rigidbody2D _Rigid;
    private SpriteRenderer _Sr;
    private Skill skill;
    private string skillName;
    private bool isRight = true;
    private bool isCloaking = false;
    private bool isShielding = false;
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
        UseSkill(x, y, playerid);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetSkill(collision.gameObject);
    }
    void GetSkill(GameObject prof) 
    {
       bool profFlag = false;
        if (skill != null)
        {
            Debug.Log("您的技能未使用完成");
            return;
        }
        string skillTag = prof.tag;
        switch (skillTag)
        {
            case "cloaking":
                skill = new Cloaking("cloaking", 2);
                Debug.Log($"技能名为{skill.skillName}");
                Debug.Log($"隐身时长{((Cloaking)skill).duration}");
                skillName = "cloaking";
                profFlag = true;
                break;
            case "shield":
                skill = new Shield("shield", 2);
                Debug.Log($"技能名为{skill.skillName}");
                Debug.Log($"盾时长{((Shield)skill).duration}");
                skillName = "shield";
                profFlag = true;
                break;
            case "attack":
                skill = new Attack("attack",3) ;
                Debug.Log($"技能名为{skill.skillName}");
                Debug.Log($"攻击存在次数{((Attack)skill).times}");
                skillName = "attack";
                profFlag = true;
                break;
        }
        if (profFlag)
        {
            //Todo:修改ui中的道具框？
            GameObject profGenerator = GameObject.FindGameObjectWithTag("propgenerator");
            ObjectGenerator objectGenerator = profGenerator.GetComponent<ObjectGenerator>();
            objectGenerator.generatedObjects.Remove(prof);
            Destroy(prof);
        }
    }
    void UseSkill(float x, float y,int playerid)
    {
        if (playerid == 1)
        {
            if (skill != null && Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log($"我使用了{skillName}");
                switch (skillName)
                {
                    case "cloaking":
                        if (!((Cloaking)skill).isUsed)
                        {
                            //使用隐身
                            Debug.Log("我使用了隐身");
                            _Sr.color = new Color(_Sr.color.r, _Sr.color.g, _Sr.color.b, _Sr.color.a * 0.5f);
                            ((Cloaking)skill).isUsed = true;
                            isCloaking = true;
                        }
                        break;
                    case "shield":
                        if (!((Shield)skill).isUsed)
                        {
                            //使用护盾
                            Debug.Log("我使用了护盾");
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
                                bullet.SetDirection(Vector3.right);
                            }
                            else
                            {
                                bullet.SetDirection(Vector3.left);
                            }
                        }
                        else
                        {
                            bullet.SetDirection((new Vector3(x, y)).normalized);
                        }
                        ((Attack)skill).times -= 1;
                        Debug.Log("发射子弹");
                        Debug.Log($"剩余子弹{((Attack)skill).times}");
                        break;
                }
            }
        }
        else
        {
            if (skill != null && Input.GetKeyUp(KeyCode.Return))
            {
                Debug.Log($"我使用了{skillName}");
                switch (skillName)
                {
                    case "cloaking":
                        if (!((Cloaking)skill).isUsed)
                        {
                            //使用隐身
                            Debug.Log("我使用了隐身");
                            _Sr.color = new Color(_Sr.color.r, _Sr.color.g, _Sr.color.b, _Sr.color.a * 0.5f);
                            ((Cloaking)skill).isUsed = true;
                            isCloaking = true;
                        }
                        break;
                    case "shield":
                        if (!((Shield)skill).isUsed)
                        {
                            //使用护盾
                            Debug.Log("我使用了护盾");
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
                                bullet.SetDirection(Vector3.right);
                            }
                            else
                            {
                                bullet.SetDirection(Vector3.left);
                            }
                        }
                        else
                        {
                            bullet.SetDirection((new Vector3(x, y)).normalized);
                        }
                        ((Attack)skill).times -= 1;
                        Debug.Log("发射子弹");
                        Debug.Log($"剩余子弹{((Attack)skill).times}");
                        break;
                }
            }
        }
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
                    Debug.Log("结束隐身");
                    //结束隐身
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
                    Debug.Log("结束护盾");
                    //结束盾
                }
            }
            if ((skillName == "attack"))
            {
                if (((Attack)skill).times <= 0)
                {
                    skill = null;
                    skillName = null;
                    Debug.Log("子弹已使用完成");
                    //结束攻击
                }
            }
        }
    }

}