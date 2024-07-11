using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff1 : MonoBehaviour
{
    public SpriteRenderer sr;//组件
    public Sprite[] pic;//图片
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // 示例玩家
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        Player playerCom1 = player1.GetComponent<Player>();
        // 抽取一个随机坐骑
        Broom selectedBroom = Broom.ExtractBroom();
        Debug.Log($"玩家1抽取到坐骑：{selectedBroom.broomName}");
        if(selectedBroom.broomName=="普通扫帚")
        {
            sr.sprite= pic[0];
        }
        else if (selectedBroom.broomName == "彗星")
        {

            sr.sprite = pic[1];
        }
        else if (selectedBroom.broomName == "光轮2000")
        {

            sr.sprite = pic[2];
        }
        else if (selectedBroom.broomName == "光轮2001")
        {

            sr.sprite = pic[3];
        }
        else if (selectedBroom.broomName == "火弩箭")
        {

            sr.sprite = pic[4];
        }
        // 应用坐骑的加成效果
        selectedBroom.ApplyBuff(playerCom1);

        // 输出玩家的属性（经过坐骑加成后）
        Debug.Log($"玩家1最大移速：{playerCom1.maxspeed}");
        Debug.Log($"玩家1加速度：{playerCom1.acceleration}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
