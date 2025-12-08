using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class skill_Data_Table
{
    /// <summary>
    /// Skill_ID
    /// </summary>
    public int key;

    /// <summary>
    /// Name
    /// </summary>
    public string Name;

    /// <summary>
    /// SkillType
    /// </summary>
    public DesignEnums.SkillTypes SkillType;

    /// <summary>
    /// DamageMultiplier
    /// </summary>
    public float DamageMultiplier;

    /// <summary>
    /// Cooldown
    /// </summary>
    public int Cooldown;

    /// <summary>
    /// StaminaCost
    /// </summary>
    public int StaminaCost;

    /// <summary>
    /// Range
    /// </summary>
    public int Range;

    /// <summary>
    /// Angle
    /// </summary>
    public int Angle;

    /// <summary>
    /// SkillTypes List
    /// </summary>
    public List<DesignEnums.SkillTypes> SkillTypes;

}
public class skill_Data_TableLoader
{
    public List<skill_Data_Table> ItemsList { get; private set; }
    public Dictionary<int, skill_Data_Table> ItemsDict { get; private set; }

    public skill_Data_TableLoader(string path = "JSON/skill_Data_Table")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, skill_Data_Table>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<skill_Data_Table> Items;
    }

    public skill_Data_Table GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public skill_Data_Table GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
