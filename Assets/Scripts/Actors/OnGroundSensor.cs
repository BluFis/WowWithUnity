using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviour
{
    // Start is called before the first frame update
    public CapsuleCollider capcol;
    private Vector3 point1;
    private Vector3 point2;
    private float radius;
    public float offset = 0.3f;
    void Awake()
    {
        radius = capcol.radius-0.05f;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        point1 = transform.position + transform.up * (radius - offset);
        point2 = transform.position + transform.up * (capcol.height - offset) - transform.up * radius;

        if (Physics.OverlapCapsule(point1, point2, radius,LayerMask.GetMask("Ground")).Length!=0)
        {
            
            SendMessageUpwards("IsGround");

        }
        else
        {
            SendMessageUpwards("IsNotGround");
        }
    }
}
