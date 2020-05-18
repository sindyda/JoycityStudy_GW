using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNE_InputComponent
{
    public UNE_InputComponent() { }
    public virtual void Update(UNE.GameObject go) { }
}

public class Player_InputComponent : UNE_InputComponent
{
    public Player_InputComponent() { }
    public override void Update(UNE.GameObject go)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            go.velocity -= UNE.WALK_ACCELERATION;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            go.velocity += UNE.WALK_ACCELERATION;
        }
    }
}