using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PositionState
{
    OnGround,AirBorne,InWater
}
public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private LookAtIK lak;
    AnimationController _instance;
    private void Awake()
    {
        lak = GetComponent<LookAtIK>();
        _instance = this;
    }
    public void Walk(Vector2 moveDir)
    {
        anim.SetFloat("yDir", moveDir.y);
        anim.SetFloat("xDir", moveDir.x);
        
        if (moveDir != Vector2.zero)
        {

            if (moveDir.x==0)
            {
                lak.enabled = false;
            }
            else
            {
                lak.enabled = true;
            }
            float angle = Vector2.Angle(moveDir, Vector2.up);
            if (moveDir.y >= 0 && moveDir.x >= 0)
            {
                transform.localEulerAngles = Vector3.up * angle;
            }
            else if (moveDir.y >= 0 && moveDir.x <= 0)
            {
                transform.localEulerAngles = -Vector3.up * angle;
            }
            else if (moveDir.y <= 0 && moveDir.x <= 0)
            {
                transform.localEulerAngles = Vector3.up * (moveDir.x == 0 ? 0 : 45);
            }
            else if (moveDir.y <= 0 && moveDir.x >= 0)
            {
                transform.localEulerAngles = -Vector3.up * 45;
            }

        }
        else
        {
            lak.enabled = false;
            transform.localEulerAngles = Vector3.zero;

        }

    }
    public void Jump()
    {
        anim.SetTrigger("Jump");
    }
    public void TurnStart(float dir)
    {
        anim.SetFloat("Turn", dir > 0 ? 1 : -1);
    }
    public void TurnEnded()
    {
        anim.SetFloat("Turn", 0);
    }
    public void ChangeState(PositionState ps)
    {
        switch (ps)
        {
            case PositionState.OnGround:
                anim.SetBool("IsOnGround", true);
                break;
            case PositionState.AirBorne:
                anim.SetBool("IsOnGround", false);
                break;
            case PositionState.InWater:
                break;
            default:
                break;
        }
    }
   public void Sit()
    {
        anim.SetTrigger("Sit");
    }

}
