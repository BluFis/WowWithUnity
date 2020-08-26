using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCastMessage : MonoBehaviour
{
    public static BoardCastMessage _instance;
    void Awake()
    {
        _instance = this;
    }
    public void BoardCast(string Message)
    {
        this.GetComponent<UILabel>().text = Message;
        this.GetComponents<TweenAlpha>()[0].PlayForward();
        this.GetComponents<TweenAlpha>()[1].PlayForward();

    }
}
