using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnUI : MonoBehaviour
{
    // Start is called before the first frame update
    public UserInput ui;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UICamera.isOverUI)
        {
            ui.IsMouseHoldOverUi = true;
        }
        else
        {
            ui.IsMouseHoldOverUi = false;
        }
    }
}
