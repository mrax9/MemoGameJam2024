using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GoldenBall : MonoBehaviour
{
    public float AvoidSpeed = 8f;
    public float checkDistance = 3;
    public int scoreOfGolden = 3;
    public float livingTime = 10;
    private float hasLivingTime = 0;
    public float checkTime = 2;
    private float checkingTime = 2;
    private GameObject player1;
    private GameObject player2;
    private GameObject goldenGenerator;
    private Rigidbody2D _Rigid;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        goldenGenerator = GameObject.FindGameObjectWithTag("goldengenerator");
        _Rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hasLivingTime += Time.deltaTime;
        if (hasLivingTime >= livingTime)
        {
            goldenGenerator.GetComponent<GolenBallGenerator>().generatedObjects.Remove(gameObject);
            Destroy(gameObject);


        }
        float distance1 = Vector2.Distance(transform.position, player1.transform.position);
        float distance2 = Vector2.Distance(transform.position, player2.transform.position);
        if (checkingTime > checkTime)
        {
            //æ‡¿Î≈–∂œ
            if (distance1 < checkDistance)
            {
                Avoid(player1);
                Debug.Log($"ºÏ≤‚µΩ{player2.name}");
            }
            else if (distance2 < checkDistance)
            {
                //π•ª˜ÕÊº“∂˛
                Debug.Log($"ºÏ≤‚µΩ{player2.name}");
                Avoid(player2);
            }
        }
        checkingTime += Time.deltaTime;
    }
    void Avoid(GameObject player)
    {
        checkingTime = 0;
        _Rigid.velocity = (-(player.transform.position - transform.position)).normalized * AvoidSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGO = collision.gameObject;
        if (collisionGO.CompareTag("Player1") || collisionGO.CompareTag("Player2"))
        {
            collisionGO.GetComponent<Player>().goldenthievesscore += scoreOfGolden;
            goldenGenerator.GetComponent<GolenBallGenerator>().generatedObjects.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
