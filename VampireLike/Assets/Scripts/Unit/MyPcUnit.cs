using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPcUnit : UnitBase
{
    public int mExp { get; set; }
    public int mMaxExp { get; set; }
    public int mLevel { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void InitUnit(int InUnitId, int InHp, int InPower, int InArmor)
    {
        base.InitUnit(InUnitId, InHp, InPower, InArmor);
        mExp = 0;
        mMaxExp = MAX_EXP_FROM_LEVEL_VALUE;
        mLevel = 1;
    }

    public override void OnHit(int InDamage)
    {
        base.OnHit(InDamage);
    }

    public override void OnDie()
    {
        base.OnDie();
    }

    public void SetUpLevel(int InLevel)
    {
        mLevel = InLevel;
        mExp = 0;
        mMaxExp = MAX_EXP_FROM_LEVEL_VALUE * InLevel;
    }

    private const int MAX_EXP_FROM_LEVEL_VALUE = 10000;
}
