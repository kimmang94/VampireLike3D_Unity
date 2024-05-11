using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStageStateExit : FSMStateBase
{
    public FSMStageStateExit() : base(EFSMStageStateType.StageStart)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
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
