using System;

public static class DesignEnums
{
    public enum SkillTypes
    {
        Damage = 0,
        Heal = 1,
        Buff = 2,
        Debuff = 3,
    }
    public enum MonsterTypes
    {
        Melee = 0,
        Ranged = 1,
        Hybrid = 2,
    }
    public enum ItemTypes
    {
        Consumable = 0,
        Material = 1,
        Weapon = 2,
        Armor = 3,
    }
    public enum Raritys
    {
        Common = 0,
        Uncommon = 1,
        Rare = 2,
        Epic = 3,
        Legendary = 4,
    }
}
