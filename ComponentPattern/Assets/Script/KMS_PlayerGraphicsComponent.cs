using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_PlayerGraphicsComponent : KMS_GraphicsComponent
{
    public override void Update(KMS_ComponentsPattern obj)
    {
        switch( obj.state)
        {
            case CHAR_STATE.GROUND:
                break;
            case CHAR_STATE.JUMP:
                break;
        }
    }
}
