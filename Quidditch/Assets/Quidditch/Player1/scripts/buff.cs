using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
            // 示例玩家
            GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            Player playerCom1 = player1.GetComponent<Player>();
            Player playerCom2 = player2.GetComponent<Player>();
            // 抽取一个随机坐骑
            Broom selectedBroom = Broom.ExtractBroom();
            Debug.Log($"抽取到坐骑：{selectedBroom.broomName}");

            // 应用坐骑的加成效果
            selectedBroom.ApplyBuff(playerCom1);

            // 输出玩家的属性（经过坐骑加成后）
            Debug.Log($"玩家最大移速：{playerCom1.maxspeed}");
            Debug.Log($"玩家加速度：{playerCom1.acceleration}");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
