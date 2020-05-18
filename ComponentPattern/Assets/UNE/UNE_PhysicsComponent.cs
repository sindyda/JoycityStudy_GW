using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNE_PhysicsComponent
{
    public UNE_PhysicsComponent() { }
    public virtual void Update(UNE.GameObject go) { }
}

public class Player_PhysicsComponent : UNE_PhysicsComponent
{
    public Player_PhysicsComponent() { }
    public override void Update(UNE.GameObject go)
    {
        go.posX += go.velocity;
    }
}