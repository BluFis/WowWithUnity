using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemUI : MonoBehaviour
{
    // Start is called before the first frame update
    private UISprite sprite;
    private UILabel label;
    private UILabel timeLabel;
    private InventoryItem _it;
    private UISprite cd;
    public InventoryItem it
    {
        get
        {
            _it = this.transform.Find("BagItem").GetComponent<InventoryDetail>().It;
            return _it;
        }
        set
        {
            _it = value;
        }
    }
    public UILabel TimeLabel
    {
        get
        {
            timeLabel = transform.Find("CD/Label").GetComponent<UILabel>();
            return timeLabel;
        }
    }
    private UISprite CD
    {
        get
        {
            cd = transform.Find("CD").GetComponent<UISprite>();
            return cd;
        }
    }
    private UISprite Sprite
    {
        get
        {
            sprite = transform.Find("BagItem").GetComponent<UISprite>();
            return sprite;
        }
    }
    private UILabel Label
    {
        get
        {
            label = transform.Find("BagItem/Label").GetComponentInChildren<UILabel>();
            return label;
        }
    }
    public void BeginCD()
    {
        it.ResetCD();
        TimeLabel.text = it.Inventory.CDTime.ToString();
        CD.gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        
        if (it==null)
        {
            return;
        }
        if (it.IsCD)
        {
            it.timmer -= Time.fixedDeltaTime;
            TimeLabel.text = ((int)it.timmer).ToString();
            CD.fillAmount = it.timmer / it.Inventory.CDTime;
            if (Mathf.Abs(it.timmer)<0.01f)
            {
                it.timmer = 0;
                CD.gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        Sprite.gameObject.GetComponent<InventoryDetail>().It = it;
        Sprite.spriteName = it.Inventory.Icon;
        if (it.Count <= 1)
        {
            Label.text = "";
        }
        else
        {
            Label.text = it.Count.ToString();
        }
        
    }
    public void Clear()
    {
        it = null;
        Label.text = "";
        Sprite.spriteName = "00";
        Sprite.gameObject.GetComponent<InventoryDetail>().It = null;
    }
}
