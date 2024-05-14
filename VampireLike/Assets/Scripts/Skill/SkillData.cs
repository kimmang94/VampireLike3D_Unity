using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Missile,
    ManualMissile,
    MoveSpeedUp,
    MagicRain,
}

public class ActiveSkillData
{
    public SkillType Type;
    public float CoolTime;
    public float Speed;
    public Vector3 FirePosition;
}

public enum SkillActiveType
{
    Manual,
    Auto,
    Buff,
}

public class SkillLevelData
{
    public SkillType Type;
    public string Path;
    public int Level;
    public int Power;
    public float Size;
    public float Speed;
    public float ActiveTime;
    public float CoolTime;
}
public class SkillData
{
    public SkillType Type;
    public SkillActiveType ActiveType;
    public Dictionary<int, SkillLevelData> LevelDatas;
}