using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStageStateProgress : FSMStateBase
{
    public FSMStageStateProgress() : base(EFSMStageStateType.StageStart)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Stage State Progress Enter");
    }

    public override void OnPorgress(float InDeltaTime)
    {
        base.OnPorgress(InDeltaTime);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}