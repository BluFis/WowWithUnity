using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    Equip,
    Drug,
    Box
}
public enum EquipType
{
    ShoulderItem,
    ChestItem,
    WristItem,
    HandsItem,
    WaistItem,
    LegsItem,
    FeetItem,
    headItem,
    WeaponItem_2h,
    WeaponItem_1hL,
    WeaponItem_1hR,
    BackItem,
    Mount,
    Tabard,
    Shirt,
    Trinket_1,
    Trinket_2,
    Finger_1,
    Finger_2,
    Neck
}
public enum Quailty
{
    garbage, normal, good, sophisticated, epic, legend
}
public enum UseType
{
    Hp,Mp
}
public class Inventory 
{
    private int id;
    private string name;
    private string icon;
    private InventoryType inventoryType;
    private EquipType equipType;
    private int sellPrice = 0;
    private int buyPrice = 0;
    private Quailty quailty;
    private int physicDamage = 0;
    private int magicDamage = 1;
    private int extraHp = 0;
    private int extraMp = 0;
    private UseType useType;
    private InfoType infoType;
    private int useNum;
    private string des;
    private int cdTime;
    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public int CDTime
    {
        get
        {
            return cdTime;
        }
        set
        {
            cdTime = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }

    }
    public string Icon
    {
        get
        {
            return icon;
        }
        set
        {
            icon = value;
        }
    }
    public InventoryType InventoryType
    {
        get
        {
            return inventoryType;
        }
        set
        {
            inventoryType = value;
        }
    }
    public EquipType EquipType
    {
        get
        {
            return equipType;
        }
        set
        {
            equipType = value;
        }
    }
    public int SellPrice
    {
        get
        {
            return sellPrice;
        }
        set
        {
            sellPrice = value;
        }
    }
    public int BuyPrice
    {
        get
        {
            return buyPrice;
        }
        set
        {
            buyPrice = value;
        }
    }
    public Quailty Quailty
    {
        get
        {
            return quailty;
        }
        set
        {
            quailty = value;
        }
    }
    public int PhysicDamage
    {
        get
        {
            return physicDamage;
        }
        set
        {
            physicDamage = value;
        }
    }
    public int MagicDamage
    {
        get
        {
            return magicDamage;
        }
        set
        {
            magicDamage = value;
        }
    }
    public int ExtraHp
    {
        get
        {
            return extraHp;
        }
        set
        {
            extraHp = value;
        }
    }
    public int ExtraMp
    {
        get
        {
            return extraMp;
        }
        set
        {
            extraMp = value;
        }
    }
    public UseType UseType
    {
        get
        {
            return useType;
        }
        set
        {
            useType = value;
        }
    }
    public InfoType InfoType
    {
        get
        {
            return infoType;
        }
        set
        {
            infoType = value;
        }
    }
    public int UseNum
    {
        get
        {
            return useNum;
        }
        set
        {
            useNum = value;
        }
    }
    public string Des
    {
        get
        {
            return des;
        }
        set
        {
            des = value;
        }
    }
}
