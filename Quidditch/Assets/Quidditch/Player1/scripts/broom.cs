using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Broom
{
    public string broomName;
    public Player player;
    public Broom(string name)
    {
        broomName = name;
    }

    // 方法用于抽取坐骑并返回实例
    public static Broom ExtractBroom()
    {
        int rand = UnityEngine.Random.Range(0,100);

        if (rand <=50 )
        {
            return new NormalBroom("普通扫帚");
        }
        else if (rand >50&&rand<=60)
        {
            return new Comet("彗星");
        }
        else if (rand >60&&rand<=80)
        {
            return new Halo2000("光轮2000");
        }
        else if (rand >80&&rand<=90)
        {
            return new Halo2001("光轮2001");
        }
        else
        {
            return new FireCrossbow("火弩箭");
        }
    }

    // 虚方法，用于在子类中重写并实现具体的加成效果
    public virtual void ApplyBuff(Player player)
    {
        // 默认情况下，普通扫帚没有加成效果
    }
    public class NormalBroom : Broom
    {
        public NormalBroom(string name) : base(name)
        {
        }
    }
    public class Comet : Broom
    {
        public Comet(string name) : base(name)
        {
        }

        public override void ApplyBuff(Player player)
        {
            // 彗星：最大移速降低百分之2
            player.maxspeed *= 0.98f;
        }
    }
    public class Halo2000 : Broom
    {
        public Halo2000(string name) : base(name)
        {
        }

        public override void ApplyBuff(Player player)
        {
            // 光轮2000：最大移速增加百分之2
            player.maxspeed *= 1.02f;
        }
    }
    public class Halo2001 : Broom
    {
        public Halo2001(string name) : base(name)
        {
        }

        public override void ApplyBuff(Player player)
        {
            // 光轮2001：加速度提高百分之20，最大移速不变
            player.acceleration *= 1.2f;
        }
    }
    public class FireCrossbow : Broom
    {
        public FireCrossbow(string name) : base(name)
        {
        }

        public override void ApplyBuff(Player player)
        {
            // 火弩箭：加速度提高百分之10，最大移速提高百分之1
            player.acceleration *= 1.1f;
            player.maxspeed *= 1.01f;
        }
    }


}
