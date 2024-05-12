using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Stage ID
    public int mStageId = 1;
    public GameObject mMyPc;
    public Transform mNpcSpwanParent;
    public Transform mSkillObjectParent;
    public Transform mItemObjectParent;


    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.aInstance.Init();
        GameDataManager.aInstance.SetStageData(mMyPc, mNpcSpwanParent, mSkillObjectParent, mItemObjectParent);
        GameDataManager.aInstance.SetCurrentStage(mStageId);

        GamePoolManager.aInstance.Init();
        GameControl.aInstance.Init();
        SpawnManager.aInstance.Init();
        FSMStageController.aInstance.Init();
        GameControl.aInstance.SetControlObject(mMyPc);
        FSMStageController.aInstance.EnterStage();
    }

    private void OnDestroy()
    {
        GameDataManager.aInstance.Clear();
        GamePoolManager.aInstance.Clear();
        GameControl.aInstance.Clear();
        SpawnManager.aInstance.Clear();
        FSMStageController.aInstance.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        FSMStageController.aInstance.OnUpdate(Time.deltaTime);
        GameControl.aInstance.OnUpdate();
    }

    
}
