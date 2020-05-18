using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNE_GraphicsComponent
{
    public UNE_GraphicsComponent() { }
    public virtual void Update(UNE.GameObject go) { }
}

public class Player_GraphicsComponent : UNE_GraphicsComponent
{
    public Player_GraphicsComponent() { }
    public override void Update(UNE.GameObject go)
    {
        if (go?.velocity < 0)
        {
            go.scaleX = go.velocity;
        }
        else if (go?.velocity > 0)
        {
            go.scaleY = go.velocity;
        }
    }
}