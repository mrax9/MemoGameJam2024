using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 旋转 : MonoBehaviour
{
    //public GameObject targetGameObject; // 要旋转的游戏对象
    public float rotateSpeed = 90f; // 每秒旋转的速度（度/秒）
    public float duration = 8f; // 旋转的持续时间（秒）
    public Button button;
    public string latsBloomName;
    // 旋转的协程
    IEnumerator RotateForDuration()
    {
        Quaternion startRotation = gameObject.transform.rotation;
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            // 计算新的旋转量（基于时间和速度）
            float angle = Random.Range(360,721) - 90;
            
            //float ang = angle + Random.Range(1, 3) * 360;
            string bloomName = "";
            // 应用旋转（这里以绕Y轴旋转为例）
            gameObject.transform.RotateAround(button.transform.position, Vector3.forward, angle);
            float zvalue = transform.rotation.z;
            Debug.Log($"抽取到的度数是{zvalue}");
            if (zvalue >= 0 && zvalue <= 36)
            {
                bloomName = "火弩箭";
            }
            else if (zvalue > 36 &&zvalue <= 72)
            {
                bloomName = "光轮2001";
            }
            else if (zvalue > 72 && zvalue <= 108)
            {
                bloomName = "彗星";
            }
            else if (zvalue > 108 && zvalue <= 180)
            {
                bloomName = "光轮2000";
            }
            else
            {
                bloomName = "普通扫帚";
            }
            latsBloomName = bloomName;
            Debug.Log($"抽取到的是{bloomName}");
            elapsedTime += Time.deltaTime;
            // 等待下一帧
            yield return null;
        }

        // 可选：将目标对象旋转回原始状态或指定状态
        // targetGameObject.transform.rotation = startRotation;
    }

    // 调用协程的公共方法
    public void StartRotation()
    {
        StartCoroutine(RotateForDuration());
    }
}
