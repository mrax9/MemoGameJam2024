using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string skillName;
    
    public Skill( string name) 
    {
        skillName = name;
    }
}
public class Cloaking : Skill
{
    public float duration;
    public bool isUsed = false;
    public Cloaking(string skillName,float time):base( skillName)
    {
        duration = time;
    }
}
public class Shield : Skill
{
    public float duration;
    public bool isUsed = false;
    public Shield(string skillName, float time) : base(skillName)
    {
        duration = time;
    }
}
public class Attack : Skill
{
    public int times = 3;
    public Attack(string skillName, int shootTimes) : base(skillName)
    {
        times = shootTimes;
    }
}
