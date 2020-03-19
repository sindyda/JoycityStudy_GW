using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_State_Stand : KMS_StatePattern
{
    public override void Enter(GameObject obj)
    {
        Debug.Log("KMS_State_Stand Enter");
        obj.transform.Rotate(0.0f, 0.0f, 0.0f);
        obj.transform.SetPositionAndRotation(new Vector3(0, 0), Quaternion.identity);
    }

    public override KMS_StatePattern InputHandler(KMS_Charactor charactor, InputState inputState)
    {
        if (inputState == InputState.INPUT_PRESS_DOWN)
            return new KMS_State_Duck();
        else if (inputState == InputState.INPUT_PRESS_UP)
            return new KMS_State_Jump();
        else if (inputState == InputState.INPUT_PRESS_ATTACK)
            return new KMS_State_Attack();
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
