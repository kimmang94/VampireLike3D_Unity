using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData
{
    public int TotalHp = 0;
    public int Hp = 0;
    public int Power = 0;
    public int Armor = 0;
}

public class UnitBase : MonoBehaviour
{
    public bool mIsAlive { get; private set; }
    public UnitData mUnitData { get; private set; }
    public int mUnitId {  get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void InitUnit (int InUnitId, int InHp, int InPower, int InArmor)
    {
        mUnitId = InUnitId;
        mUnitData = new UnitData();
        mUnitData.TotalHp = mUnitData.Hp = InHp;
        mUnitData.Power = InPower;
        mUnitData.Armor = InArmor;
    }

    public virtual void OnHit(int InDamage)
    {
        if (mUnitData != null)
        {
            return;
        }
    }

    public virtual void OnDie()
    {

    }
}
