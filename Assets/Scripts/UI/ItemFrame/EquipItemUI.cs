using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FontColor
{
    //NGUI Label 上的文字颜色 十六进制代码
    public const string NguiLbl_Color_Garbage = "[908F91]";
    public const string NguiLbl_Color_Normal = "[FFFFFF]";
    public const string NguiLbl_Color_Good = "[00FF1B]";
    public const string NguiLbl_Color_Sophisticated = "[0027FF]";
    public const string NguiLbl_Color_Epic = "[9400FF]";
    public const string NguiLbl_Color_Legend = "[FF8C00]";
}
public class EquipItemUI : MonoBehaviour
{
    private UILabel itemName;
    private UILabel type;
    private UILabel level;
    private UILabel Hp;
    private UILabel Mp;
    private UILabel PhysicsDamage;
    private UILabel MagicDamage;
    private void Awake()
    {
        itemName = this.gameObject.transform.Find("Grid/name").gameObject.GetComponent<UILabel>();
        type = this.gameObject.transform.Find("Grid/type").gameObject.GetComponent<UILabel>();
        level = this.gameObject.transform.Find("Grid/level").gameObject.GetComponent<UILabel>();
        Hp = this.gameObject.transform.Find("Grid/Hp").gameObject.GetComponent<UILabel>();
        Mp = this.gameObject.transform.Find("Grid/Mp").gameObject.GetComponent<UILabel>();
        PhysicsDamage = this.gameObject.transform.Find("Grid/PhysicsDamage").gameObject.GetComponent<UILabel>();
        MagicDamage = this.gameObject.transform.Find("Grid/MagicDamage").gameObject.GetComponent<UILabel>();
    }
    public void Display(Inventory inventory)
    {
        
        string color=FontColor.NguiLbl_Color_Normal;
        switch (inventory.Quailty)
        {
            case Quailty.garbage:
                color = FontColor.NguiLbl_Color_Garbage;
                break;
            case Quailty.normal:
                color = FontColor.NguiLbl_Color_Normal;
                break;
            case Quailty.good:
                color = FontColor.NguiLbl_Color_Good;
                break;
            case Quailty.sophisticated:
                color = FontColor.NguiLbl_Color_Sophisticated;
                break;
            case Quailty.epic:
                color = FontColor.NguiLbl_Color_Epic;
                break;
            case Quailty.legend:
                color = FontColor.NguiLbl_Color_Legend;
                break;
            default:
                break;
        }
        itemName.text = color+inventory.Name;
        switch (inventory.EquipType.ToString())
        {
            case "ShoulderItem":
                type.text = "肩膀";
                break;
            case "ChestItem":
                type.text = "胸甲";
                break;
            case "WristItem":
                type.text = "护腕";
                break;
            case "HandsItem":
                type.text = "手套";
                break;
            case "WaistItem":
                type.text = "腰带";
                break;
            case "LegsItem":
                type.text = "腿甲";
                break;
            case "FeetItem":
                type.text = "战靴";
                break;
            case "headItem":
                type.text = "头盔";
                break;
            case "WeaponItem_2h":
                type.text = "双手武器";
                break;
            case "WeaponItem_1hL":
                type.text = "主手武器";
                break;
            case "WeaponItem_1hR":
                type.text = "副手武器";
                break;
            case "BackItem":
                type.text = "披风";
                break;
            default:
                break;
        }
        level.text = inventory.Des;
        Hp.text += inventory.ExtraHp;
        Mp.text += inventory.ExtraMp;
        PhysicsDamage.text += inventory.PhysicDamage;
        MagicDamage.text += inventory.MagicDamage;
    }
    public void UnDisplay()
    {
        itemName.text = "";
        type.text = "";
        level.text = "";
        Hp.text = "生命值：";
        Mp.text = "法力值：";
        PhysicsDamage.text = "物理伤害：";
        MagicDamage.text = "法术伤害：";
    }
}
