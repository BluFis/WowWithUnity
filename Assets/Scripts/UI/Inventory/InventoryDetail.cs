using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDetail : MonoBehaviour
{
    protected InventoryItem it;
    public EquipItemUI eu;
    public UseItemFrame uif;
    public UserInput ui;
    AddHpCommand addHpCommand = new AddHpCommand();
    AddManaCommand addManaCommand = new AddManaCommand();
    public InventoryItem It
    {
        set
        {
            it = value;
            if (it == null)
            {

            }
        }
        get
        {
            return it;
        }
    }


   public void OnMouseUp()
    {
        if (ui.Mouse1Down && It != null)
        {
            if (It.Inventory.InventoryType==InventoryType.Equip)
            {
                if (It.Inventory.EquipType!=EquipType.Mount)
                {
                    PlayerInfo._instance.DressOn(It);
                    OnMouseExit();
                    this.transform.parent.GetComponent<InventoryItemUI>().Clear();
                }
            }
            else if (It.Inventory.InventoryType == InventoryType.Drug)
            {
                if (It.IsCD)
                {
                    BoardCastMessage._instance.BoardCast("物品正在冷却中");
                    return;
                }
                if (It.Inventory.UseType==UseType.Hp)
                {
                   if( addHpCommand.execute(GameObject.FindGameObjectWithTag("Player"),new string[] { It.Inventory.UseNum.ToString() }))
                    {
                        InventoryManager._instance.UseInventory(It);
                        this.transform.parent.GetComponent<InventoryItemUI>().BeginCD();
                    }
                }
                else if (It.Inventory.UseType == UseType.Mp)
                {
                   
                    if(addManaCommand.execute(GameObject.FindGameObjectWithTag("Player"), new string[] { It.Inventory.UseNum.ToString() }))
                    {
                        InventoryManager._instance.UseInventory(It);
                        this.transform.parent.GetComponent<InventoryItemUI>().BeginCD();
                    }
                }
                OnMouseExit();
               
                

            }
        }
    }
    public void OnMouseEnter()
    {
        if (It!=null&&!ui.Mouse0Up&&!ui.Mouse1Up)
        {
            if (It.Inventory.InventoryType==InventoryType.Equip)
            {
                if (It.Inventory.EquipType!=EquipType.Mount)
                {
                    eu.gameObject.SetActive(true);
                    eu.Display(It.Inventory);
                }
            }
            else if (It.Inventory.InventoryType==InventoryType.Drug)
            {
                uif.gameObject.SetActive(true);
                uif.Display(It.Inventory);
            }
        }
       
    }
    public void OnMouseExit()
    {
        if (It != null)
        {
            if (It.Inventory.InventoryType == InventoryType.Equip)
            {
                if (It.Inventory.EquipType != EquipType.Mount)
                {
                    eu.UnDisplay();
                    eu.gameObject.SetActive(false);
                }
            }
            else if (It.Inventory.InventoryType == InventoryType.Drug)
            {
                uif.UnDisplay();
                uif.gameObject.SetActive(false);
            }
        }
    }
}
