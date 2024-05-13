using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Missile,
    ManualMissile,
    MoveSpeedUp,
}

public class ActiveSkillData
{
    public SkillType Type;
    public float CoolTime;
    public float Speed;
    public Vector3 FirePosition;
}