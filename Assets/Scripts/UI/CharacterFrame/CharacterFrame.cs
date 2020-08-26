using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFrame : MonoBehaviour
{
    public GameObject PlayerModel;
    private GameObject Player;
    public CharacterEquip Head;
    public CharacterEquip Wrist;
    public CharacterEquip Tabard;
    public CharacterEquip Shirt;
    public CharacterEquip Chest;
    public CharacterEquip Back;
    public CharacterEquip Shoulder;
    public CharacterEquip Neck;
    public CharacterEquip Feet;
    public CharacterEquip Legs;
    public CharacterEquip Waist;
    public CharacterEquip Hands;
    public CharacterEquip Trink_1;
    public CharacterEquip Trink_2;
    public CharacterEquip Finger_1;
    public CharacterEquip Finger_2;
    public CharacterEquip Weapon2h;
    public CharacterEquip Weapon1hL;
    public CharacterEquip Weapon1hR;

    private void Awake()
    {
        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
        UpdateShow();
    }

    void OnPlayerInfoChanged(InfoType type)
    {
        if (type == InfoType.Equip)
        {
            UpdateShow();
        }
    }
    void UpdateShow()
    {
        if (PlayerInfo._instance.shoulderInventory != null)
        {
            Shoulder.It = PlayerInfo._instance.shoulderInventory;
        }
        if (PlayerInfo._instance.headInventory != null)
        {
            Head.It = PlayerInfo._instance.headInventory;
        }
        if (PlayerInfo._instance.waistInventory != null)
        {
            Waist.It = PlayerInfo._instance.waistInventory;
        }
        if (PlayerInfo._instance.tabardInventory != null)
        {
            Tabard.It = PlayerInfo._instance.tabardInventory;
        }
        if (PlayerInfo._instance.shirtInventory != null)
        {
            Shirt.It = PlayerInfo._instance.shirtInventory;
        }
        if (PlayerInfo._instance.chestInventory != null)
        {
            Chest.It = PlayerInfo._instance.chestInventory;
        }
        if (PlayerInfo._instance.backInventory != null)
        {
            Back.It = PlayerInfo._instance.backInventory;
        }
        if (PlayerInfo._instance.necklaceInventory != null)
        {
            Neck.It = PlayerInfo._instance.necklaceInventory;
        }
        if (PlayerInfo._instance.feetInventory != null)
        {
            Feet.It = PlayerInfo._instance.feetInventory;
        }
        if (PlayerInfo._instance.legsInventory != null)
        {
            Legs.It = PlayerInfo._instance.legsInventory;
        }
        if (PlayerInfo._instance.wristInventory != null)
        {
            Wrist.It = PlayerInfo._instance.wristInventory;
        }
        if (PlayerInfo._instance.handsInventory != null)
        {
            Hands.It = PlayerInfo._instance.handsInventory;
        }
        if (PlayerInfo._instance.trinket1Inventory != null)
        {
            Trink_1.It = PlayerInfo._instance.trinket1Inventory;
        }
        if (PlayerInfo._instance.trinket2Inventory != null)
        {
            Trink_2.It = PlayerInfo._instance.trinket2Inventory;
        }
        if (PlayerInfo._instance.ring1Inventory != null)
        {
            Finger_1.It = PlayerInfo._instance.ring1Inventory;
        }
        if (PlayerInfo._instance.ring2Inventory != null)
        {
            Finger_2.It = PlayerInfo._instance.ring2Inventory;
        }
        if (PlayerInfo._instance.weapon2hInventory != null)
        {
            Weapon2h.It = PlayerInfo._instance.weapon2hInventory;
        }
        if (PlayerInfo._instance.weapon1hLInventory != null)
        {
            Weapon1hL.It = PlayerInfo._instance.weapon1hLInventory;
        }
        if (PlayerInfo._instance.weapon1hRInventory != null)
        {
            Weapon1hR.It = PlayerInfo._instance.weapon1hRInventory;
        }
        SetModel();
    }
    // Start is called before the first frame update
    void SetModel()
    {
        if (Player!=null)
        {
            Destroy(Player);
        }
        Player = GameObject.Instantiate(PlayerModel);
        Player.transform.parent = this.transform;
        Player.transform.localPosition = new Vector3(-10f, -20f, -40f);
        Player.transform.localScale = Vector3.one * 180f;
        Player.transform.localEulerAngles = Vector3.up * -90f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RollLeftButtonClick()
    {
        Player.transform.localEulerAngles += Vector3.up * 10f;
    }
    public void RollRightButtonClick()
    {
        Player.transform.localEulerAngles += -Vector3.up * 10f;
    }
}
