using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class GolenBallGenerator : MonoBehaviour
{
    public float generateLength;
    public float generateWidth;
    public int objectCount;
    public GameObject walkBall;
    public List<GameObject> generatedObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"开始生成游走球");
        for (int i = 0; i < objectCount; i++)
        {
            GameObject profPrefab = walkBall;
            Collider2D[] Colliders;
            float x;
            float y;
            do
            {
                x = Random.Range(-generateLength, generateLength);
                y = Random.Range(-generateWidth, generateWidth);
                Vector2 generatorPosition = new Vector2(x, y);
                Colliders = Physics2D.OverlapCircleAll(generatorPosition, profPrefab.GetComponent<CircleCollider2D>().radius);
            }
            while (Colliders.Length != 0);
            GameObject ball = Instantiate(profPrefab, new Vector3(x, y, 0), Quaternion.identity);
            //Debug.Log($"生成{ball.name}成功");
            generatedObjects.Add(ball);
        }
    }
}
