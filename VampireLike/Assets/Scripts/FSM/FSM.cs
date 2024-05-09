using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    public FSM(FSMStateBase InFSMState)
    {
       mCurrentState = InFSMState;
       if (mCurrentState == null)
       {
           mCurrentState.OnEnter();
       }
    }

    public void ChangeState(FSMStateBase InFSMBase)
    {
        if (mCurrentState == InFSMBase)
        {
            return;
        }

        if (mCurrentState != null)
        {
            mCurrentState.OnExit();
        }
        
        mCurrentState = InFSMBase;

        if (mCurrentState != null)
        {
            mCurrentState.OnEnter();
        }
    }

    public void OnUpdateState(float InDeltaTime)
    {
        if (mCurrentState != null )
        {
            mCurrentState.OnPorgress(InDeltaTime);
        }
    }

    public FSMStateBase mCurrentState {  get; private set; }
}
