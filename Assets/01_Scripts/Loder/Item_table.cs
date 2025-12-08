using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Data_table
{
    /// <summary>
    /// ItemID
    /// </summary>
    public int key;

    /// <summary>
    /// ItemName
    /// </summary>
    public string ItemName;

    /// <summary>
    /// ItemType
    /// </summary>
    public DesignEnums.ItemTypes ItemType;

    /// <summary>
    /// Rarity
    /// </summary>
    public DesignEnums.Raritys Rarity;

    /// <summary>
    /// HealAmount
    /// </summary>
    public int HealAmount;

    /// <summary>
    /// MaxStack
    /// </summary>
    public int MaxStack;

    /// <summary>
    /// IsConsumable
    /// </summary>
    public bool IsConsumable;

    /// <summary>
    /// Icon
    /// </summary>
    public string Icon;

    /// <summary>
    /// ItemTypes
    /// </summary>
    public List<DesignEnums.ItemTypes> ItemTypes;

    /// <summary>
    /// Raritys
    /// </summary>
    public List<DesignEnums.Raritys> Raritys;

}
public class Data_tableLoader
{
    public List<Data_table> ItemsList { get; private set; }
    public Dictionary<int, Data_table> ItemsDict { get; private set; }

    public Data_tableLoader(string path = "JSON/Data_table")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, Data_table>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<Data_table> Items;
    }

    public Data_table GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public Data_table GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
