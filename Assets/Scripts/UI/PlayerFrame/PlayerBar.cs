using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBar : MonoBehaviour
{
    private UISprite headSprite;
    private UILabel nameLabel;
    private UISlider HpSlider;
    private UILabel HpLabel;
    private UISlider MpSlider;
    private UILabel MpLabel;
    private UILabel levelLabel;
    
    void Awake()
    {
        headSprite = transform.Find("HeadImg").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        HpSlider = transform.Find("BarFill/HpBar").GetComponent<UISlider>();
        MpSlider = transform.Find("BarFill/MpBar").GetComponent<UISlider>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();      
        HpLabel = transform.Find("BarFill/HpLabel").GetComponent<UILabel>();
        MpLabel = transform.Find("BarFill/MpLabel").GetComponent<UILabel>();
        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;

    }
    void Start()
    {
        
    }
    void OnDestory()
    {
        PlayerInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }
    void OnPlayerInfoChanged(InfoType type)
    {
        if (type == InfoType.Name || type == InfoType.HeadPortrait || type == InfoType.Level || type==InfoType.Hp||type==InfoType.Mp||type==InfoType.All)
        {
            UpdateShow();
        }
    }
    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instance;
        headSprite.spriteName = info.HeadPortrait;
      
        levelLabel.text = info.Level.ToString();
        nameLabel.text = info.Name.ToString();
        HpSlider.value = (float)info.CurrentHp / (float)info.Hp;
        HpLabel.text = info.CurrentHp + "/"+info.Hp;
        MpSlider.value = (float)info.CurrentMp / (float)info.Mp;
        MpLabel.text = info.CurrentMp + "/" + info.Mp;
    }

}
