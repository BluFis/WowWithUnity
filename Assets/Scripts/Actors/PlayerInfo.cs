using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InfoType
{
    Name,HeadPortrait,Level,Exp,Coin,Hp,Mp,Damage,Equip,All
}
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo _instance;
    #region property
    private string _name;
    private string _headPortrait;
    private int _level = 1;

    private int _exp = 0;
    private int _mp = 0;
    private int _coin = 0;

    private int _toughen;

    private int _hp;
    private int _physicsDamage;
    private int _magicDamage;
    private int _currentHp;
    private int _currentMp;
    public InventoryItem headInventory;
    public InventoryItem chestInventory;
    public InventoryItem weapon2hInventory;
    public InventoryItem feetInventory;
    public InventoryItem necklaceInventory;
    public InventoryItem ring1Inventory;
    public InventoryItem ring2Inventory;
    public InventoryItem shoulderInventory;
    public InventoryItem wristInventory;
    public InventoryItem handsInventory;
    public InventoryItem weapon1hRInventory;
    public InventoryItem waistInventory;
    public InventoryItem legsInventory;
    public InventoryItem weapon1hLInventory;
    public InventoryItem mountInventory;
    public InventoryItem backInventory;
    public InventoryItem tabardInventory; 
    public InventoryItem shirtInventory;
    public InventoryItem trinket2Inventory;
    public InventoryItem trinket1Inventory;
    #endregion
    public delegate void OnPlayerInfoChangedEvent(InfoType type);
    public event OnPlayerInfoChangedEvent OnPlayerInfoChanged; 
    #region get set method
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public string HeadPortrait
    {
        get
        {
            return _headPortrait;
        }
        set
        {
            _headPortrait = value;
        }
    }
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }
    public int CurrentHp
    {
        get
        {
            return _currentHp;
        }
        set
        {
            _currentHp = value;
        }
    }
    public int CurrentMp
    {
        get
        {
            return _currentMp;
        }
        set
        {
            _currentMp = value;
        }
    }
    public int Mp
    {
        get
        {
            return _mp;
        }
        set
        {
            _mp = value;
        }
    }
    public int Exp
    {
        get
        {
            return _exp;
        }
        set
        {
            _exp = value;
        }
    }

    public int Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            _coin = value;
        }
    }
   
    public int Toughen
    {
        get
        {
            return _toughen;
        }
        set
        {
            _toughen = value;
        }
    }
    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    public int PhysicsDamage
    {
        get
        {
            return _physicsDamage;
        }
        set
        {
            _physicsDamage = value;
        }
    }
   public int MagicDamage
    {
        get
        {
            return _magicDamage;
        }
        set
        {
            _magicDamage = value;
        }
    }
    #endregion
    #region unity event
    void Awake()
    {
        _instance = this;
        
    }
    private void Start()
    {
       
        OnPlayerInfoChanged(InfoType.All);
    }
    #endregion

    
    public void ChangeName(string newName)
    {
        this.Name = newName;
        OnPlayerInfoChanged(InfoType.Name);
    }
   public bool AddHp(int value)
    {
        if (this.CurrentHp==this.Hp)
        {
            BoardCastMessage._instance.BoardCast("不需要补充生命值");
            return false;
        }
        else
        {
            
            this.CurrentHp = Mathf.Clamp(this.CurrentHp + value, this.CurrentHp,this.Hp);
            OnPlayerInfoChanged(InfoType.Hp);
            return true;
        }
        
        
    }
    public bool AddMp(int value)
    {
        if (this.CurrentMp == this.Mp)
        {
            BoardCastMessage._instance.BoardCast("不需要补充法力值");
            return false;
        }
        else
        {
            this.CurrentMp = Mathf.Clamp(this.CurrentMp + value, this.CurrentMp, this.Mp);
            OnPlayerInfoChanged(InfoType.Mp);
            return true;
        }
    }
    
    public void DressOn(InventoryItem it)
    {
        it.IsDressed = true;
        //检测有无相同装备
        bool isDressed = false;
        InventoryItem inventoryItemDressed = null;
        switch (it.Inventory.EquipType)
        {
            case EquipType.BackItem:
                if (backInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = backInventory;

                }
                backInventory = it;
                break;
            case EquipType.ChestItem:
                if (chestInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = chestInventory;

                }
                chestInventory = it;
                break;
            case EquipType.FeetItem:
                if (feetInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = feetInventory;

                }
                feetInventory = it;
                break;
            case EquipType.HandsItem:
                if (handsInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = handsInventory;

                }
                handsInventory = it;
                break;
            case EquipType.headItem:
                if (headInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = headInventory;

                }
                headInventory = it;
                break;
            case EquipType.LegsItem:
                if (legsInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = legsInventory;

                }
                legsInventory = it;
                break;
            case EquipType.Mount:
                if (mountInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = mountInventory;

                }
                mountInventory = it;
                break;
            case EquipType.ShoulderItem:
                if (shoulderInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = shoulderInventory;

                }
                shoulderInventory = it;
                break;
            case EquipType.WaistItem:
                if (waistInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = waistInventory;

                }
                waistInventory = it;
                break;
            case EquipType.WeaponItem_1hL:
                if (weapon1hLInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = weapon1hLInventory;

                }
                weapon1hLInventory = it;
                break;
            case EquipType.WeaponItem_1hR:
                if (weapon1hRInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = weapon1hRInventory;

                }
                weapon1hRInventory = it;
                break;
            case EquipType.WeaponItem_2h:
                if (weapon2hInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = weapon2hInventory;

                }
                weapon2hInventory = it;
                break;
            case EquipType.WristItem:
                if (wristInventory != null)
                {
                    isDressed = true;
                    inventoryItemDressed = wristInventory;

                }
                wristInventory = it;
                break;
        }
        if (isDressed)
        {
            inventoryItemDressed.IsDressed = false;
            InventoryUI._instance.AddInventoryItem(inventoryItemDressed);
        }
        OnPlayerInfoChanged(InfoType.Equip);
    }
    public void DressOff(InventoryItem it)
    {
        switch (it.Inventory.EquipType)
        {
            case EquipType.BackItem:
                if (backInventory != null)
                {
                    backInventory = null;

                }

                break;
            case EquipType.ChestItem:
                if (chestInventory!= null)
                {
                    chestInventory = null;

                }

                break;
            case EquipType.FeetItem:
                if (feetInventory != null)
                {
                    feetInventory = null;

                }

                break;
            case EquipType.HandsItem:
                if (handsInventory != null)
                {
                    handsInventory = null;

                }

                break;
            case EquipType.headItem:
                if (headInventory != null)
                {
                    headInventory = null;

                }

                break;
            case EquipType.LegsItem:
                if (legsInventory != null)
                {
                    legsInventory = null;

                }

                break;
            case EquipType.Mount:
                if (mountInventory != null)
                {
                    mountInventory = null;

                }

                break;
            case EquipType.ShoulderItem:
                if (shoulderInventory != null)
                {
                    shoulderInventory = null;

                }

                break;
            case EquipType.WaistItem:
                if (waistInventory != null)
                {
                    waistInventory = null;

                }

                break;
            case EquipType.WeaponItem_1hL:
                if (weapon1hLInventory != null)
                {
                    weapon1hLInventory = null;

                }
                break;
            case EquipType.WeaponItem_1hR:
                if (weapon1hRInventory != null)
                {
                    weapon1hRInventory = null;

                }
                break;
            case EquipType.WeaponItem_2h:
                if (weapon2hInventory != null)
                {
                    weapon2hInventory = null;

                }

                break;
            case EquipType.WristItem:
                if (wristInventory != null)
                {
                    wristInventory = null;

                }

                break;
        }
        it.IsDressed = false;
        InventoryUI._instance.AddInventoryItem(it);
        OnPlayerInfoChanged(InfoType.Equip);
    }
    void PutOnEquipment(int id)
    {
        if (id == 0) return;
        Inventory inventory = InventoryManager._instance.ReadInventoryById(id);
        this.Hp += inventory.ExtraHp;
        this.Mp += inventory.ExtraMp;
        this.PhysicsDamage += inventory.PhysicDamage;
        this.MagicDamage += inventory.MagicDamage;
    }
    void PutOffEquipment(int id)
    {
        if (id == 0) return;
        Inventory inventory = InventoryManager._instance.ReadInventoryById(id);
        this.Hp -= inventory.ExtraHp;
        this.Mp -= inventory.ExtraMp;
        this.PhysicsDamage -= inventory.PhysicDamage;
        this.MagicDamage -= inventory.MagicDamage;
    }
}
