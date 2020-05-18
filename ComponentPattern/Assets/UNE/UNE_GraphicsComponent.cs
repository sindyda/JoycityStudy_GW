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
            go.image.rectTransform.localPosition = new Vector3(go.image.rectTransform.localPosition.x + go.velocity, go.image.rectTransform.localPosition.y, go.image.rectTransform.localPosition.z);
        }
        else if (go?.velocity > 0)
        {
            go.image.rectTransform.localPosition = new Vector3(go.image.rectTransform.localPosition.x, go.image.rectTransform.localPosition.y + go.velocity, go.image.rectTransform.localPosition.z);
        }
    }
}