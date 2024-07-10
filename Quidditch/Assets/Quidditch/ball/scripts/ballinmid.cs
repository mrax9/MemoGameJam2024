using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ballinmid : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D _v;
    public Vector2 startPosition = new Vector2(0, -4);
    // 我们在 inspector 中可以直接修改 public 变量
    // 这里我们设置一个初始位置变量
    void Start()
    {
        _v = GetComponent<Rigidbody2D>();
        setball();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("发生碰撞");
        GameObject collisionGo = collision.gameObject;
        if (collisionGo.CompareTag("player1score"))
        {
            Debug.Log("判定成功");
            setball();
        }
        else if (collisionGo.CompareTag("player2score"))
        {
            Debug.Log("判定成功");
            setball();
        }
    }

    private void setball()
    {
        transform.position = startPosition;
        _v.velocity = new Vector2(0, 5);
    }
}