using UnityEngine;

public abstract class Command
{
    public abstract bool execute(GameObject actor,string[] args);
}
