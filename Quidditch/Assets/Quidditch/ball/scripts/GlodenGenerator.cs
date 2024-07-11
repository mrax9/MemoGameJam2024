using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class GolenBallGenerator : MonoBehaviour
{
    public float generalizedTime = 180;
    public float generalizedDeltaTime = 20;
    private float generalizedTimeOfNow = 0;
    private float generalizedDeltaTimeOfNow = 20;
    public float generateLength;
    public float generateWidth;
    public int objectCount;
    public GameObject glodenkBall;
    public List<GameObject> generatedObjects = new List<GameObject>();
    private bool generalizedFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        generalizedTimeOfNow += Time.deltaTime;
        if (generatedObjects.Count == 0)
        {
            generalizedDeltaTimeOfNow += Time.deltaTime;
        }
        if (generalizedTimeOfNow > generalizedTime)
        {
            generalizedFlag = true;
        }
        if (generalizedFlag && generalizedDeltaTimeOfNow >= generalizedDeltaTime && generatedObjects.Count == 0)
        {
            GeneralizeGloden();
            generalizedDeltaTimeOfNow = 0;
        }

    }
    void GeneralizeGloden()
    {
        Debug.Log($"开始生成金色飞贼");
        for (int i = 0; i < objectCount; i++)
        {
            GameObject profPrefab = glodenkBall;
            Collider2D[] Colliders;
            float x;
            float y;
            do
            {
                x = Random.Range(-generateLength, generateLength);
                y = Random.Range(-generateWidth, generateWidth);
                Vector2 generatorPosition = new Vector2(x, y);
                Colliders = Physics2D.OverlapCapsuleAll(generatorPosition, profPrefab.GetComponent<CapsuleCollider2D>().size, profPrefab.GetComponent<CapsuleCollider2D>().direction, 0);
            }
            while (Colliders.Length != 0);
            GameObject ball = Instantiate(profPrefab, new Vector3(x, y, 0), Quaternion.identity);
            //Debug.Log($"生成{ball.name}成功");
            generatedObjects.Add(ball);
        }
    }

}
