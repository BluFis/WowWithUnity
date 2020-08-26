using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public UserInput ui;
    public AnimationController ac;
    public Rigidbody rb;
    public Vector2 WalkSpeed = new Vector2(1,1);
    public Vector2 RunSpeed = new Vector2(2, 2);
    public PositionState ps = PositionState.OnGround;
    public float jumpForce = 10.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //check move
        if (ui.MoveDir!=Vector2.zero)
        {
            transform.Translate(new Vector3(-(ui.IsWalk ? WalkSpeed.x : RunSpeed.x) * ui.MoveDir.x * Time.fixedDeltaTime, 0, (ui.IsWalk ? WalkSpeed.y : RunSpeed.y) * ui.MoveDir.y * Time.fixedDeltaTime));           
        }
        ac.Walk((ui.IsWalk ? 1 : 2) * new Vector2(ui.Dright, ui.Dup));
        if (ui.Jump&&ps==PositionState.OnGround)
        {
            ac.Jump();
        }
    }
    public void OnJumpEnter()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }
    public void IsGround()
    {
        ps = PositionState.OnGround;
        ac.ChangeState(ps);
    }
    public void IsNotGround()
    {
        ps = PositionState.AirBorne;
        ac.ChangeState(ps);
    }
}
