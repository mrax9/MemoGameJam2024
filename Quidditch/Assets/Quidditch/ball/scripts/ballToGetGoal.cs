using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ballToGetGoal : MonoBehaviour
{
    private Rigidbody2D _ballin;
    // Start is called before the first frame update
    void Start()
    {
        _ballin = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGo = collision.gameObject;
        if (collisionGo.CompareTag("player1score"))
        {
            GameObject play1 = GameObject.FindGameObjectWithTag("Player1");
            Player playerComponent = play1.GetComponent<Player>();
            playerComponent.ballscore += 1;
        }
        else if (collisionGo.CompareTag("player2score"))
        {
            GameObject Play2 = GameObject.FindGameObjectWithTag("Player2");
            Player playerComponent = Play2.GetComponent<Player>();
            playerComponent.ballscore += 1;
        }
        else
        {
            
        }

    }
}
