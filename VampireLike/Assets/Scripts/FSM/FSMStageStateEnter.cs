using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStageStateEnter : FSMStateBase
{
    public FSMStageStateEnter() : base(EFSMStageStateType.StageStart)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnPorgress(float InDeltaTime)
    {
        base.OnPorgress(InDeltaTime);
        mDurationTime += InDeltaTime;
        if (mDurationTime > 1.0f)
        {
            if (mCountDown <= 0)
            {
                FSMStageController.aInstance.ChangeState(new FSMStageStateProgress());
            }
            else
            {
                mCountDown--;
                Debug.Log("Count Down " +  mCountDown);
            }
            mDurationTime = 0.0f;
        }



    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("Stage State Enter Exit");
        mDurationTime = 0;
    }

    private int mCountDown = 3;
    private float mDurationTime = 0;
}
