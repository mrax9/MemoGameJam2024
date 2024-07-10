using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CheckScore : MonoBehaviour
{
    public int player1BallScore;
    public int player2BallScore;
    private Player player1Component;
    private Player player2Component;
    // Start is called before the first frame update
    void Start()
    {
        GameObject play1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject Play2 = GameObject.FindGameObjectWithTag("Player2");
        player1Component = Play2.GetComponent<Player>();
        player2Component = Play2.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        player1BallScore = player1Component.ballscore;
        player2BallScore = player2Component.ballscore;
    }
}
