using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItemUI : MonoBehaviour
{
    private UISprite sprite;
    public InventoryItem it;
    private UISprite Sprite
    {
        get
        {
            if (sprite == null)
            {
                sprite = transform.Find("Equip").GetComponent<UISprite>();
            }
            return sprite;
        }
    }
    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        Sprite.gameObject.GetComponent<CharacterEquip>().It = it;
        Sprite.spriteName = it.Inventory.Icon;
    }
    public void Clear()
    {
        it = null;
        Sprite.spriteName = "";
        Sprite.gameObject.GetComponent<CharacterEquip>().It = null;
    }
}
