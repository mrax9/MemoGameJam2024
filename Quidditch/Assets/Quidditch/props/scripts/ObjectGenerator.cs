using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectGenerator : MonoBehaviour
{
    public float generateLength;
    public float generateWidth;
    public int objectCount;
    public float generatePropTime;
    private Player player1Component;
    private Player player2Component;
    private int player1BallScore = 0;
    private int player2BallScore = 0;
    public List<GameObject> skills = new List<GameObject>();
    public List<GameObject> generatedObjects = new List<GameObject>();
    private float timeOfNoScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject play1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject Play2 = GameObject.FindGameObjectWithTag("Player2");
        player1Component = play1.GetComponent<Player>();
        player2Component = Play2.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player1BallScore != player1Component.ballscore)
        {
            timeOfNoScore = 0;
            player1BallScore = player1Component.ballscore;
        }
        else if (player2BallScore != player2Component.ballscore)
        {
            timeOfNoScore = 0;
            player2BallScore = player2Component.ballscore;
        }
        else if(generatedObjects.Count == 0)
        {
            timeOfNoScore += Time.deltaTime;
        }
        if (timeOfNoScore > generatePropTime && generatedObjects.Count == 0)
        {
            Debug.Log($"开始生成");
            for (int i = 0; i < objectCount; i++)
            {
                GameObject profPrefab;
                Collider2D[] Colliders;
                float x;
                float y;
                do
                {
                    x = Random.Range(-generateLength, generateLength);
                    y = Random.Range(-generateWidth, generateWidth);
                    int profIndex = Random.Range(0, skills.Count);
                    profPrefab = skills[profIndex];
                    Vector2 generatorPosition = new Vector2(x, y);
                    Colliders = Physics2D.OverlapBoxAll(generatorPosition, new Vector2(profPrefab.transform.localScale.x/2, profPrefab.transform.localScale.y/2), 0);
                }
                while (Colliders.Length != 0);
                GameObject skill = Instantiate(profPrefab, new Vector3(x, y, 0), Quaternion.identity);
                //Debug.Log($"生成{skill.name}成功");
                generatedObjects.Add(skill);
            }
            timeOfNoScore = 0;
        }
    }
}
