using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    
    public static InventoryManager _instance;
    private SQLiteHelper sql;

    public List<InventoryItem> InventoryItemList = new List<InventoryItem>();
    private readonly string dbPath = string.Format("Data Source={0}", Path.Combine(Environment.CurrentDirectory, "Assets\\Data\\wow.db"));
    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent OnInventoryChange;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        ReadInventoryItemInfo();
    }
    public Inventory ReadInventoryById(int id)
    {
        sql = new SQLiteHelper(dbPath);
        SqliteDataReader reader = sql.ReadTableSelected("UserInventoryView", "ID", id.ToString());
        Inventory inventory = new Inventory();
        while (reader.Read())
        {
            //读取ID
            inventory.ID = reader.GetInt32(reader.GetOrdinal("ID"));
            //读取Name
            inventory.Name = reader.GetString(reader.GetOrdinal("ItemName"));
            //读取Icon
            inventory.Icon = reader.GetString(reader.GetOrdinal("IconName"));
            switch (reader.GetString(reader.GetOrdinal("ItemType")))
            {
                case "Equip":
                    inventory.InventoryType = InventoryType.Equip;
                    break;
                case "Drug":
                    inventory.InventoryType = InventoryType.Drug;
                    break;
                case "Box":
                    inventory.InventoryType = InventoryType.Box;
                    break;
            }
            if (inventory.InventoryType == InventoryType.Equip)
            {
                switch (reader.GetString(reader.GetOrdinal("EquipmentType")))
                {
                    case "ShoulderItem":
                        inventory.EquipType = EquipType.ShoulderItem;
                        break;
                    case "ChestItem":
                        inventory.EquipType = EquipType.ChestItem;
                        break;
                    case "WristItem":
                        inventory.EquipType = EquipType.WristItem;
                        break;
                    case "HandsItem":
                        inventory.EquipType = EquipType.HandsItem;
                        break;
                    case "WaistItem":
                        inventory.EquipType = EquipType.WaistItem;
                        break;
                    case "LegsItem":
                        inventory.EquipType = EquipType.LegsItem;
                        break;
                    case "FeetItem":
                        inventory.EquipType = EquipType.FeetItem;
                        break;
                    case "headItem":
                        inventory.EquipType = EquipType.headItem;
                        break;
                    case "WeaponItem_2h":
                        inventory.EquipType = EquipType.WeaponItem_2h;
                        break;
                    case "WeaponItem_1hL":
                        inventory.EquipType = EquipType.WeaponItem_1hL;
                        break;
                    case "WeaponItem_1hR":
                        inventory.EquipType = EquipType.WeaponItem_1hR;
                        break;
                    case "BackItem":
                        inventory.EquipType = EquipType.BackItem;
                        break;
                }
                //print(item);
                
                inventory.PhysicDamage = reader.GetInt32(reader.GetOrdinal("PhysicsDamage"));
                inventory.MagicDamage = reader.GetInt32(reader.GetOrdinal("MagicDamage"));
                
                inventory.ExtraHp = reader.GetInt32(reader.GetOrdinal("ExtraHp"));
                inventory.ExtraMp = reader.GetInt32(reader.GetOrdinal("ExtraMp"));
            }
            else if (inventory.InventoryType == InventoryType.Drug)
            {
                switch (reader.GetString(reader.GetOrdinal("UseType")))
                {
                    case "Hp":
                        inventory.UseType = UseType.Hp;
                        break;
                    case "Mp":
                        inventory.UseType = UseType.Mp;
                        break;
                    default:
                        break;
                }
                inventory.UseNum= reader.GetInt32(reader.GetOrdinal("UseNum"));
                inventory.CDTime = reader.GetInt32(reader.GetOrdinal("CDTime"));

            }
            switch (reader.GetString(reader.GetOrdinal("QualityName")))
            {
                case "garbage":
                    inventory.Quailty = Quailty.garbage;
                    break;
                case "normal":
                    inventory.Quailty = Quailty.normal;
                    break;
                case "good":
                    inventory.Quailty = Quailty.good;
                    break;
                case "sophisticated":
                    inventory.Quailty = Quailty.sophisticated;
                    break;
                case "epic":
                    inventory.Quailty = Quailty.epic;
                    break;
                case "legend":
                    inventory.Quailty = Quailty.legend;
                    break;
                default:
                    break;
            }
            inventory.SellPrice = reader.GetInt32(reader.GetOrdinal("SellPrice"));
            inventory.BuyPrice = reader.GetInt32(reader.GetOrdinal("BuyPrice"));
            inventory.Des = reader.GetString(reader.GetOrdinal("Desciption"));
        }
        sql.CloseConnection();
        return inventory;
    }
    void ReadInventoryItemInfo()
    {
        sql = new SQLiteHelper(dbPath);
        SqliteDataReader reader = sql.ReadFullTable("UserInventory");
        while (reader.Read())
        {
            Inventory inven = ReadInventoryById(reader.GetInt32(reader.GetOrdinal("Item")));
            if (inven.InventoryType == InventoryType.Equip)
            {
                InventoryItem it = new InventoryItem();
                it.Inventory = inven;
                it.Level = UnityEngine.Random.Range(1, 10);
                it.Count = 1;
                InventoryItemList.Add(it);
            }
            else
            {
                 InventoryItem it = new InventoryItem();
                 it.Inventory = inven;
                 it.Count = reader.GetInt32(reader.GetOrdinal("Amount"));
                 InventoryItemList.Add(it);

            }

            sql.CloseConnection();
        }
        OnInventoryChange();
    }
    public void UseInventory(InventoryItem it)
    {
        if (it.Count == 1)
        {
            InventoryItemList.Remove(it);
        }
        else
        {
            it.Count--;

        }
        OnInventoryChange();
    }
}
