using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddManaCommand : Command
{
    public override bool execute(GameObject actor,string[] value)
    {
        return actor.GetComponent<PlayerInfo>().AddMp(int.Parse(value[0]));
        
    }
}
