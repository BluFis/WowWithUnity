using UnityEngine;
using System.Collections;
//N0.0-----------------------------------------  
//    装备的交换与拖住啊 （surface代表放下时撞到的物体）  
//N0.0-----------------------------------------  
//  
public enum ContainerTag
{
    Container,Equipments,SkillTable
}
public class ExchangableItem: UIDragDropItem
{
    private ContainerTag ct;
    private InventoryDetail id;

    private ContainerTag GetContainerTag(string tagName)
    {
        switch (tagName)
        {
            case "Container":
                return ContainerTag.Container;
            case "Equipments":
                return ContainerTag.Equipments;
            case "SkillTable":
                return ContainerTag.SkillTable;
            default:
                return ContainerTag.Container;
        }
    }
    protected override void OnDragStart()
    {
        id = this.gameObject.GetComponent<InventoryDetail>();
        if (id.It==null)
        {
            return;
        }
        base.OnDragStart();
        this.gameObject.GetComponent<UISprite>().depth++;
        ct = GetContainerTag(this.tag);
    }
    protected override void OnDragDropMove(Vector2 delta)
    {
        base.OnDragDropMove(delta);
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        print(surface.tag);

        if (surface.tag == this.tag)
        {
            ExchangeItemsInSameTag(surface);
        }
        else
        {
            if (surface.tag==ContainerTag.Container.ToString())
            {
                if (this.tag==ContainerTag.Equipments.ToString())
                {
                    PlayerInfo._instance.DressOff(this.GetComponent<CharacterEquip>().It);
                    this.transform.parent.GetComponent<EquipmentItemUI>().Clear();
                    this.transform.localPosition = Vector3.zero;
                }
            }else if(surface.tag== ContainerTag.Equipments.ToString())
            {
                if (this.tag==ContainerTag.Container.ToString())
                {
                    PlayerInfo._instance.DressOn(this.GetComponent<InventoryDetail>().It);
                    this.transform.parent.GetComponent<InventoryItemUI>().Clear();
                    this.transform.localPosition = Vector3.zero;
                }
                
            }
            else if (surface.tag=="Untagged")
            {
                this.transform.localPosition = Vector3.zero;
            }
        }

        this.gameObject.GetComponent<UISprite>().depth--;
    }
    private void ExchangeItemsInSameTag(GameObject surface)
    {
        if (GetContainerTag(this.tag)!=ContainerTag.Equipments)
        {
            Exchange(surface);
        }
        else
        {
            CharacterEquip ce_surface = surface.gameObject.GetComponent<CharacterEquip>();
            CharacterEquip ce_this = this.gameObject.GetComponent<CharacterEquip>();
            if (ce_surface.eq==EquipType.Finger_1||ce_surface.eq==EquipType.Finger_2)
            {
                if (ce_this.eq == EquipType.Finger_1 || ce_this.eq == EquipType.Finger_2)
                {
                    Exchange(surface);
                    return;
                }
            }
            else if (ce_surface.eq == EquipType.Trinket_1 || ce_surface.eq == EquipType.Trinket_2)
            {
                if (ce_this.eq == EquipType.Trinket_1 || ce_this.eq == EquipType.Trinket_2)
                {
                    Exchange(surface);
                    return;
                }
            }
            transform.localPosition = Vector3.zero;
        }
    }
    private void Exchange(GameObject surface)
    {
        var parent = surface.gameObject.transform.parent;
        surface.gameObject.transform.parent = this.gameObject.transform.parent;
        surface.gameObject.transform.localPosition = Vector3.zero;
        this.gameObject.transform.parent = parent;
        this.gameObject.transform.localPosition = Vector3.zero;
    }
}