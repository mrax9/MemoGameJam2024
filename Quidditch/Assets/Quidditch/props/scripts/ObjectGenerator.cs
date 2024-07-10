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
    public List<GameObject> skills = new List<GameObject>();
    public List<GameObject> generatedObjects = new List<GameObject>();
    private float timeOfNoScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (generatedObjects.Count == 0)
        {
            timeOfNoScore += Time.deltaTime;
        }
        if (timeOfNoScore > 3 && generatedObjects.Count == 0)
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
                Debug.Log($"生成{skill.name}成功");
                generatedObjects.Add(skill);
            }
            timeOfNoScore = 0;
        }
    }
}
