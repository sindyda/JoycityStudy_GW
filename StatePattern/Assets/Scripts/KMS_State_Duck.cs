using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_State_Duck : KMS_StatePattern
{
    public override void Enter(GameObject obj)
    {
        Debug.Log("KMS_State_Duck Enter");
        obj.transform.Rotate(0.0f, 0.0f, 90.0f);
    }

    public override KMS_StatePattern InputHandler(KMS_Charactor charactor, InputState inputState)
    {
        if (inputState == InputState.INPUT_RELEASE_DOWN)
            return new KMS_State_Stand();

        return null;
    }

    public override KMS_StatePattern Update(GameObject obj)
    {
        return null;
    }

    public override void Exit(GameObject obj)
    {
    }
}
