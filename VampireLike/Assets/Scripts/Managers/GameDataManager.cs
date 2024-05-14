using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Unity.VisualScripting.Antlr3.Runtime;

public class GameDataManager
{
    public int mStage { get; private set; }
    public static GameDataManager aInstance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = new GameDataManager();
            }
            return sInstance;
        }
    }
    public GameObject GetMypcObject()
    {
        return myPc;
    }
    public Transform GetSpawnRootTransform()
    {
        return mSpawnRoot;
    }
    public Transform GetItemRootTransform()
    {
        return mItemRoot;
    }
    public Transform GetSkillRootTransform()
    {
        return mSkillRoot;
    }
    public void Init()
    {
        
    }

    public void Clear()
    {
        mStage = 0;
        myPc = null;
        mSpawnRoot = null;
        mItemRoot = null;
        mSkillRoot = null;

        SkillDatas.Clear();
        SkillDatas = null;

        SkillResources.Clear();
        SkillResources = null;
    }

    public void LoadAll()
    {
        LoadSkillData();
    }

    public void LoadSkillData()
    {
        SkillDatas = new Dictionary<SkillType, SkillData>();
        SkillResources = new Dictionary<string, SkillBase>();
        SkillDatas.Clear();
        SkillResources.Clear();

        TextAsset SkillJsonTextAsset = Resources.Load<TextAsset>("Data/SkillDatas");
        string ISkillJosn = SkillJsonTextAsset.text;
        JObject IDataObject = JObject.Parse(ISkillJosn);
        JToken IToken = IDataObject["Skills"];
        JArray IArray = IToken.Value<JArray>();

        foreach (JObject EachObject in IArray)
        {
            SkillData NewSkillData = new SkillData();
            NewSkillData.Type = Enum.Parse<SkillType>(EachObject.Value<string>("Type"));
            NewSkillData.ActiveType = Enum.Parse<SkillActiveType>(EachObject.Value<string>("ActiveType"));
            NewSkillData.LevelDatas = new Dictionary<int, SkillLevelData>();
            JArray ILevelArray = EachObject.Value<JArray>("LevelDatas");
            foreach(JObject EachLevel in ILevelArray)
            {
                SkillLevelData NewSkillLevelData = new SkillLevelData();
                NewSkillLevelData.Type = NewSkillData.Type;
                NewSkillLevelData.Level = EachLevel.Value<int>("Level");
                NewSkillLevelData.Path = EachLevel.Value<string>("Path");
                NewSkillLevelData.Power = EachLevel.Value<int>("Power");
                NewSkillLevelData.Size = EachLevel.Value<int>("Size");
                NewSkillLevelData.Speed = EachLevel.Value<float>("Speed");
                NewSkillLevelData.ActiveTime = EachLevel.Value<float>("ActiveTime");
                NewSkillLevelData.CoolTime = EachLevel.Value<float>("CoolTime");

                NewSkillData.LevelDatas.Add(NewSkillLevelData.Level, NewSkillLevelData);

                SkillBase SkillObject = Resources.Load<SkillBase>(NewSkillLevelData.Path);
                string SkillId = GetSkillId(NewSkillLevelData);
                SkillResources.Add(SkillId, SkillObject);
            }
            SkillDatas.Add(NewSkillData.Type, NewSkillData);
        }
    }

    public string GetSkillId(SkillLevelData InSkillLevelData)
    {
        return string.Format("{0}_{1}", InSkillLevelData.Type.ToString(), InSkillLevelData.Level);
    }
    
    public void SetStageData(GameObject InMyPc, Transform InSpawnRoot, Transform InSkillRoot, Transform InItemRoot)
    {
        myPc = InMyPc;
        mSpawnRoot = InSpawnRoot;
        mSkillRoot = InSkillRoot;
        mItemRoot = InItemRoot;
    }

    public void SetCurrentStage(int InStage)
    {
        mStage = InStage;
    }

    private static GameDataManager sInstance = null;

    private GameObject myPc;
    private Transform mSpawnRoot;
    private Transform mSkillRoot;
    private Transform mItemRoot;

    private Dictionary<SkillType, SkillData> SkillDatas = null;
    private Dictionary<string, SkillBase> SkillResources = null;
}
