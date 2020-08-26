using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemFrame : MonoBehaviour
{
    private UILabel itemName;
    private UILabel desciption;
    // Start is called before the first frame update
    void Awake()
    {
        itemName = this.gameObject.transform.Find("Grid/name").gameObject.GetComponent<UILabel>();
        desciption = this.gameObject.transform.Find("Grid/Desciption").gameObject.GetComponent<UILabel>();
    }

    // Update is called once per frame
    public void Display(Inventory inventory)
    {
        string color = FontColor.NguiLbl_Color_Normal;
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
        itemName.text = color + inventory.Name;
        desciption.text = inventory.Des;
    }
    public void UnDisplay()
    {
        itemName.text = "";
        desciption.text = "";
    }
}
