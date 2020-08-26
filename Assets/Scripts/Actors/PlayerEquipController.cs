using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipController:MonoBehaviour
{
    public static PlayerEquipController _instance;
    public GameObject HeadItem;
    public GameObject BackItem;
    public GameObject ShoulderItemLeft;
    public GameObject ShoulderItemRight;
    public GameObject Weapon;
    public GameObject LeftArm;
    public GameObject RightArm;
    public GameObject LeftWrist;
    public GameObject RightWrist;
    public GameObject LeftBoot0;
    public GameObject LeftBoot1;
    public GameObject RightBoot0;
    public GameObject RightBoot1;
    public GameObject WaistItem;
    public GameObject Body;
    public CapsuleCollider[] capsuleColliders;
    private void Awake()
    {
        _instance = this;
        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
        DressUp();
    }

    private void OnPlayerInfoChanged(InfoType type)
    {
        if (type==InfoType.Equip)
        {
            DressUp();
        }
    }

    public void DressUp() {
        if (PlayerInfo._instance.shoulderInventory != null)
        {
            DressOff(ShoulderItemLeft);
            DressOff(ShoulderItemRight);
            DressOn("Items/Equipments/Prefebs/LeftShoulder" + PlayerInfo._instance.shoulderInventory.Inventory.ID, ShoulderItemLeft);
            DressOn("Items/Equipments/Prefebs/RightShoulder" + PlayerInfo._instance.shoulderInventory.Inventory.ID, ShoulderItemRight);
        }
        else
        {
            DressOff(ShoulderItemLeft);
            DressOff(ShoulderItemRight);
        }
        if (PlayerInfo._instance.headInventory != null)
        {
            DressOff(HeadItem);
            DressOn("Items/Equipments/Prefebs/HeadItem" + PlayerInfo._instance.headInventory.Inventory.ID, HeadItem);
        }
        else
        {
            DressOff(HeadItem);
        }
        if (PlayerInfo._instance.waistInventory != null)
        {
            DressOff(WaistItem);
            DressOn("Items/Equipments/Prefebs/WaistItem" + PlayerInfo._instance.waistInventory.Inventory.ID, WaistItem);
        }
        else
        {
            DressOff(WaistItem);
            DressOn("Items/Equipments/Prefebs/WaistItemOrgin", WaistItem);
        }
        if (PlayerInfo._instance.tabardInventory != null)
        {
           // Tabard.It = PlayerInfo._instance.tabardInventory;
        }
        if (PlayerInfo._instance.shirtInventory != null)
        {
           // Shirt.It = PlayerInfo._instance.shirtInventory;
        }
        if (PlayerInfo._instance.chestInventory != null)
        {
            DressOffMaterials(Body, EquipType.ChestItem);
            DressOnMaterials(Body, EquipType.ChestItem, "Items/Equipments/Prefebs/ChestItem" + PlayerInfo._instance.chestInventory.Inventory.ID);
        }
        else
        {
            DressOffMaterials(Body, EquipType.ChestItem);
        }
        if (PlayerInfo._instance.backInventory != null)
        {
            DressOff(BackItem);
            DressOn("Items/Equipments/Prefebs/BackItem" + PlayerInfo._instance.backInventory.Inventory.ID, BackItem);
            Cloth cloth=BackItem.transform.Find("BackItem" + PlayerInfo._instance.backInventory.Inventory.ID + "(Clone)").Find("Cloak9").GetComponent<Cloth>();
            cloth.capsuleColliders = capsuleColliders;
        }
        else
        {
            DressOff(BackItem);
        }
        if (PlayerInfo._instance.necklaceInventory != null)
        {
            //Neck.It = PlayerInfo._instance.necklaceInventory;
        }
        if (PlayerInfo._instance.feetInventory != null)
        {
            DressOff(LeftBoot0);
            DressOff(LeftBoot1);
            DressOff(RightBoot0);
            DressOff(RightBoot1);
            DressOn("Items/Equipments/Prefebs/LeftBoot0" + PlayerInfo._instance.feetInventory.Inventory.ID, LeftBoot0);
            DressOn("Items/Equipments/Prefebs/LeftBoot1" + PlayerInfo._instance.feetInventory.Inventory.ID, LeftBoot1);
            DressOn("Items/Equipments/Prefebs/RightBoot0" + PlayerInfo._instance.feetInventory.Inventory.ID, RightBoot0);
            DressOn("Items/Equipments/Prefebs/RightBoot1" + PlayerInfo._instance.feetInventory.Inventory.ID, RightBoot1);
            DressOffMaterials(Body, EquipType.FeetItem);
            DressOnMaterials(Body, EquipType.FeetItem, "Items/Equipments/Prefebs/FeetItem" + PlayerInfo._instance.feetInventory.Inventory.ID);
        }
        else
        {
            DressOff(LeftBoot0);
            DressOff(LeftBoot1);
            DressOff(RightBoot0);
            DressOff(RightBoot1);
            DressOffMaterials(Body, EquipType.FeetItem);
        }
        if (PlayerInfo._instance.legsInventory != null)
        {
            DressOffMaterials(Body, EquipType.LegsItem);
            DressOnMaterials(Body, EquipType.LegsItem, "Items/Equipments/Prefebs/LegsItem" + PlayerInfo._instance.legsInventory.Inventory.ID);
        }
        else
        {
            DressOffMaterials(Body, EquipType.LegsItem);
        }
        if (PlayerInfo._instance.wristInventory != null)
        {
            DressOff(LeftWrist);
            DressOff(RightWrist);
            DressOn("Items/Equipments/Prefebs/LeftWristItem" + PlayerInfo._instance.wristInventory.Inventory.ID, LeftWrist);
            DressOn("Items/Equipments/Prefebs/RightWristItem" + PlayerInfo._instance.wristInventory.Inventory.ID, RightWrist);
        }
        else
        {
            DressOff(LeftWrist);
            DressOff(RightWrist);
        }
        if (PlayerInfo._instance.handsInventory != null)
        {
            DressOffMaterials(Body, EquipType.HandsItem);
            DressOnMaterials(Body, EquipType.HandsItem, "Items/Equipments/Prefebs/HandsItem" + PlayerInfo._instance.handsInventory.Inventory.ID);
        }
        else
        {
            DressOffMaterials(Body, EquipType.HandsItem);
        }
        if (PlayerInfo._instance.trinket1Inventory != null)
        {
            //Trink_1.It = PlayerInfo._instance.trinket1Inventory;
        }
        if (PlayerInfo._instance.trinket2Inventory != null)
        {
            //Trink_2.It = PlayerInfo._instance.trinket2Inventory;
        }
        if (PlayerInfo._instance.ring1Inventory != null)
        {
           // Finger_1.It = PlayerInfo._instance.ring1Inventory;
        }
        if (PlayerInfo._instance.ring2Inventory != null)
        {
            //Finger_2.It = PlayerInfo._instance.ring2Inventory;
        }
        if (PlayerInfo._instance.weapon2hInventory != null)
        {
            DressOff(Weapon);
            DressOn("Items/Equipments/Prefebs/Sword" + PlayerInfo._instance.weapon2hInventory.Inventory.ID, Weapon);
        }
        else
        {
            DressOff(Weapon);
        }
        if (PlayerInfo._instance.weapon1hLInventory != null)
        {
           // Weapon1hL.It = PlayerInfo._instance.weapon1hLInventory;
        }
        if (PlayerInfo._instance.weapon1hRInventory != null)
        {
           // Weapon1hR.It = PlayerInfo._instance.weapon1hRInventory;
        }
    }
    private void DressOn(string url,GameObject parent)
    {
        GameObject obj = (GameObject)Instantiate(Resources.Load(url));
        obj.transform.SetParent(parent.transform);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        obj.transform.localEulerAngles = Vector3.zero;
    }
    private void DressOff(GameObject item)
    {
        item.transform.DestroyChildren();
    }
    private void DressOffMaterials(GameObject item,EquipType type)
    {
        SkinnedMeshRenderer skinnedMeshRenderer = item.gameObject.GetComponent<SkinnedMeshRenderer>();
        Material mat = Resources.Load<Material>("Items/Equipments/Prefebs/ChestOld");
        if (type==EquipType.ChestItem)
        {
            
            skinnedMeshRenderer.materials[9].CopyPropertiesFromMaterial(mat);

        }
        else if (type==EquipType.HandsItem)
        {
            skinnedMeshRenderer.materials[0].CopyPropertiesFromMaterial(mat);
        }
        else if (type==EquipType.LegsItem)
        {
            skinnedMeshRenderer.materials[6].CopyPropertiesFromMaterial(mat);
        }
        else if(type==EquipType.FeetItem)
        {
            skinnedMeshRenderer.materials[8].CopyPropertiesFromMaterial(mat);
        }
    }
    private void DressOnMaterials(GameObject item,EquipType type,string url)
    {
        SkinnedMeshRenderer skinnedMeshRenderer = item.gameObject.GetComponent<SkinnedMeshRenderer>();
        Material mat = Resources.Load<Material>(url);
        if (type == EquipType.ChestItem)
        {
            
            skinnedMeshRenderer.materials[9].CopyPropertiesFromMaterial(mat);

        }
        else if (type==EquipType.HandsItem)
        {
            skinnedMeshRenderer.materials[0].CopyPropertiesFromMaterial(mat);
        }
        else if (type==EquipType.LegsItem)
        {
            skinnedMeshRenderer.materials[6].CopyPropertiesFromMaterial(mat);
        }
        else if (type == EquipType.FeetItem)
        {
            skinnedMeshRenderer.materials[8].CopyPropertiesFromMaterial(mat);
        }

    }
}
