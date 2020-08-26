using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBarSettings : MonoBehaviour
{
    public UISprite CharacterFrame;
    public bool isCharacterFrameActive;
    // Start is called before the first frame update
    void Awake()
    {
        isCharacterFrameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPlayerBtnClicked()
    {
        CharacterFrame.gameObject.SetActive(!isCharacterFrameActive);
        isCharacterFrameActive = !isCharacterFrameActive;
    }
}
