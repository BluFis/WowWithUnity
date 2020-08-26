using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquip : InventoryDetail
{
    public EquipType eq;
    public new InventoryItem It
    {
        set
        {
            if (value==null)
            {
                it = value;
                this.gameObject.GetComponent<UISprite>().spriteName = "00";
            }
            else
            {
                it = value;
                this.gameObject.GetComponent<UISprite>().spriteName = it.Inventory.Icon;
            }
           
        }
        get
        {
            return it;
        }
    }
    new void OnMouseUp()
    {
        if (ui.Mouse1Down && It != null)
        {         
            PlayerInfo._instance.DressOff(It);
            OnMouseExit();
            this.transform.parent.GetComponent<EquipmentItemUI>().Clear();
        }
    }
    
}
