using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkBallGenerator : MonoBehaviour
{
    public float[] generateSize1;
    public float[] generateSize2;
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
            if (i == 0)
            {
                do
                {
                    x = Random.Range(generateSize1[0], generateSize1[1]);
                    y = Random.Range(generateSize1[2], generateSize1[3]);
                    Vector2 generatorPosition = new Vector2(x, y);
                    Colliders = Physics2D.OverlapCircleAll(generatorPosition, profPrefab.GetComponent<CircleCollider2D>().radius);
                }
                while (Colliders.Length != 0);
                GameObject ball = Instantiate(profPrefab, new Vector3(x, y, 0), Quaternion.identity);
                //Debug.Log($"生成{ball.name}成功");
                generatedObjects.Add(ball);
            }
            else if (i == 1)
            {
                do
                {
                    x = Random.Range(generateSize2[0], generateSize2[1]);
                    y = Random.Range(generateSize2[2], generateSize2[3]);
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
}
