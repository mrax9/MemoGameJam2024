using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _Rigid;
    private SpriteRenderer _Sr;
    public float speed = 3;
    private bool isRight = true;
    void Start()
    {
        _Sr = GetComponent<SpriteRenderer>();
        _Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Debug.Log($"X:{x} Y:{y}");
        Move(x,y);
        Flip(x);
    }

    void Move(float x, float y)
    {
        _Rigid.velocity = new Vector2(x * speed, y * speed);
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
}