using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManualMissile : SkillBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void FireSkill(ActiveSkillData InSkillData, Vector3 InStartPos, Vector3 InStartDir)
    {
        base.FireSkill(InSkillData, InStartPos, InStartDir);
        mSkillType = SkillType.ManualMissile;
        StartCoroutine(_OnMissileLifeTime());
    }

    public IEnumerator _OnMissileLifeTime()
    {
        float CurrentLifeTime = 0.0f;
        while(true)
        {
            Vector3 AddForceVector = mStartDir * mActiveSkillData.Speed * Time.deltaTime;
            transform.position += new Vector3(AddForceVector.x, 0, AddForceVector.z);
            CurrentLifeTime += Time.deltaTime;
            if (CurrentLifeTime > 2.0f)
            {
                break;
            }
            yield return null;
        }
        StopSkill();
    }
}
