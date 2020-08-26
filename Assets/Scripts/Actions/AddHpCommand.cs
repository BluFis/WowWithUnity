using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHpCommand : Command
{
    public override bool execute(GameObject actor,string[] value)
    {
        return actor.GetComponent<PlayerInfo>().AddHp(int.Parse(value[0]));
    }
}
