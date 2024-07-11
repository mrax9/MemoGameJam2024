using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;
    public float LiveTime = 10f;
    public float force = 500;
    private Vector2 _Direction;
    private float _HasLiveTime = 0;
    private Rigidbody2D _Rigidbody;
    private int owner;
    private Vector2 lastDir;
    private void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        _Rigidbody.velocity = (_Direction * Speed);
    }

    private void Update()
    {
        lastDir = _Rigidbody.velocity.normalized;
        _HasLiveTime += Time.deltaTime;
        if (_HasLiveTime > LiveTime)
        {
            Destroy(gameObject);
        }
    }
    public void BasicSet(Vector2 dir, int ownerGet)
    {
        owner = ownerGet;
        _Direction = dir;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        if (tag == "Player1" || tag == "Player2")
        {
            int id = int.Parse(tag.Substring(tag.Length - 1, 1));
            if (id != owner)
            {
                Debug.Log($"当前的tag为{tag}当前的id为{id}");
                if (!collision.gameObject.GetComponent<Player>().isShielding)
                {
                    rigidbody2D.AddForce(lastDir * force, ForceMode2D.Force);
                    Debug.Log($"子弹{gameObject.name}成功击中{collision.gameObject.name}");
                }
                
                Destroy(gameObject);
            }
            else if (id == owner)
            {
                Destroy(gameObject);
            }
        }
        else if (tag == "walkball")
        { 
            rigidbody2D.AddForce(lastDir * force /10, ForceMode2D.Force);
            Destroy(gameObject);
        }
        else 
        {
            return;
        }
    }
}
