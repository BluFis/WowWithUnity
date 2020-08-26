using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public List<InventoryItemUI> itemList = new List<InventoryItemUI>();
    public static InventoryUI _instance;
    private UILabel goldLabel;
    private UILabel sliverLabel;
    private UILabel copperLabel;
    public PlayerInfo pi;
    void Awake()
    {
        _instance = this;
        foreach (InventoryItemUI item in transform.GetComponentsInChildren<InventoryItemUI>())
        {
            itemList.Add(item);
        }
       
        goldLabel = this.gameObject.transform.Find("GoldLabel").GetComponent<UILabel>();
        sliverLabel = this.gameObject.transform.Find("SliverLabel").GetComponent<UILabel>();
        copperLabel = this.gameObject.transform.Find("CopperLabel").GetComponent<UILabel>();
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChanged;
        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
        UpdateMoney();
    }

    void OnPlayerInfoChanged(InfoType type)
    {
        UpdateMoney();
    }

    void OnInventoryChanged()
    {
        UpdateShow();
       
    }

    private void UpdateMoney()
    {
        this.goldLabel.text = (pi.Coin / 10000).ToString();
        this.sliverLabel.text = ((pi.Coin % 10000)/100).ToString();
        this.copperLabel.text = (pi.Coin%100).ToString();
    }

    public void OnDestory()
    {
        InventoryManager._instance.OnInventoryChange -= this.OnInventoryChanged;
        PlayerInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    void UpdateShow()
    {

        for(int i = 0; i < InventoryManager._instance.InventoryItemList.Count; i++)
        {
            
            InventoryItem it = InventoryManager._instance.InventoryItemList[i];
            itemList[i].SetInventoryItem(it);
        }
        for(int i = InventoryManager._instance.InventoryItemList.Count; i < itemList.Count; i++)
        {
            itemList[i].Clear();
        }
    }
    public void AddInventoryItem(InventoryItem it)
    {
        foreach(InventoryItemUI itUI in itemList)
        {
            if (itUI.it == null)
            {
                itUI.SetInventoryItem(it);
                break;
            }
        }
    }
}
