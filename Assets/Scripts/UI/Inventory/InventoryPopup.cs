using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPopup : MonoBehaviour
{
    // Start is called before the first frame update
    private UILabel nameLabel;
    private UISprite InventorySprite;
    private UILabel desLabel;
    private UILabel btnLabel;
    private InventoryItem it;
    void Awake()
    {
        nameLabel=transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        InventorySprite= transform.Find("Bg/Sprite/Sprite").GetComponent<UISprite>();
        desLabel= transform.Find("Bg/Label").GetComponent<UILabel>();
        btnLabel= transform.Find("Bg/ButtonUseBatching/Label").GetComponent<UILabel>();
    }
    public void Show(InventoryItem it)
    {
        this.gameObject.SetActive(true);
        this.it = it;
        nameLabel.text = it.Inventory.Name;
        InventorySprite.spriteName = it.Inventory.Icon;
        desLabel.text = it.Inventory.Des;
        btnLabel.text = "批量使用（" + it.Count + ")";

    }
}
