using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInfo;

public class BagManager : MonoBehaviour
{
    public UISprite bagFrame;
    private bool isBagShow = false;
    public void OnBagIconClicked()
    {
       
        if (isBagShow)
        {
            bagFrame.GetComponent<InventoryUI>().OnDestory();
            bagFrame.gameObject.SetActive(!isBagShow);
            isBagShow = !isBagShow;
        }
        else
        {
            bagFrame.gameObject.SetActive(!isBagShow);
            isBagShow = !isBagShow;

        }
        
    }
}
