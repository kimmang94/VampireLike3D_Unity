using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoolManager
{
    public static GamePoolManager aInstance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new GamePoolManager();
            }
            return sInstance;
        }
    }
    public void Init()
    {
        SkillPool = new Dictionary<SkillType, Queue<SkillBase>>();
    }

    public void Clear()
    {
        SkillPool.Clear();
        SkillPool = null;
    }

    public void EnqueueSkillPool(SkillBase InSkill)
    {
        if (SkillPool == null)
        {
            return;
        }
        if (SkillPool.ContainsKey(InSkill.mSkillType) == false )
        {
            SkillPool.Add(InSkill.mSkillType, new Queue<SkillBase>());
        }
        SkillPool[InSkill.mSkillType].Enqueue(InSkill);
    }

    public SkillBase DequeueSkillPool(SkillType InSkillType)
    {
        if (SkillPool == null)
        {
            return null;
        }
        if (SkillPool.ContainsKey(InSkillType) == false)
        {
            return null;
        }

        return SkillPool[InSkillType].Dequeue();
    }

    private Dictionary<SkillType, Queue<SkillBase>> SkillPool = null;
    private static GamePoolManager sInstance = null;

}
