using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserInput : MonoBehaviour
{
    private bool isWalk = true;
    private bool _isMouseHoldOverUi=false;
    public string walkShift = "left ctrl";
    public string jump = "space";
    public float Dright
    {
        get
        {
            return Input.GetAxisRaw("Horizontal");
        }
    }
    public float Dup
    {
        get
        {
            return Input.GetAxisRaw("Vertical");
        }
    }
    public Vector2 MoveDir
    {
        get
        {
            return new Vector2(Dup, Dright).normalized;
        }
    }
    public bool Mouse0Hold
    {
        get
        {
            if (Input.GetButton("Fire1")&&!_isMouseHoldOverUi)
             {
                 Cursor.visible = false;
                 return true;
            }
            else
            {
                Cursor.visible = true;
                return false;
            }
        }
    }
    public bool IsMouseHoldOverUi
    {
        get
        {
            return _isMouseHoldOverUi;
        }
        set
        {
            _isMouseHoldOverUi = value;
        }
    }
    public bool Mouse1Hold
    {
        get
        {
            if (Input.GetButton("Fire2")&& !_isMouseHoldOverUi)
            {
                Cursor.visible = false;
                return true;
            }
            else
            {
                Cursor.visible = true;
                return false;
            }
        }
    }
    public bool Mouse1Up
    {
        get
        {
            if (Input.GetMouseButtonUp(1))
            {
                return true;

            }
            return false;
        }
    }
    public bool Mouse0Up
    {
        get
        {
            if (Input.GetMouseButtonUp(0))
            {
                return true;

            }
            return false;
        }
    }
    public bool Mouse1Down
    {
        get
        {
            if (Input.GetMouseButtonDown(1))
            {
                return true;

            }
            return false;
        }
    }
    public bool Mouse0Down
    {
        get
        {
            if (Input.GetMouseButtonDown(0))
            {
                return true;

            }
            return false;
        }
    }
    public float Mright
    {
        get
        {
            if (Mouse1Hold||Mouse0Hold)
            {
                return Input.GetAxis("Mouse X");
            }
            else
            {
                return 0;
            }
        }
    }
    public float Mup
    {
        get
        {
            if (Mouse1Hold || Mouse0Hold)
            {
                return Input.GetAxis("Mouse Y");
            }
            else
            {
                return 0;
            }
        }
    }
    public bool IsWalk
    {
        get
        {
            return isWalk;
        }
    }
    public bool Jump
    {
        get
        {
            if (Input.GetKeyUp(jump))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(walkShift))
        {
            isWalk = !isWalk;
        }
    }
    
}
