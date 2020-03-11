using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputState
{
    INPUT_PRESS_DOWN,
    INPUT_RELEASE_DOWN,
    INPUT_PRESS_UP
}

public class KMS_StatePattern
{
    public virtual void Enter(GameObject obj)
    {
        Debug.Log("KMS_State Enter");
    }

    public virtual KMS_StatePattern InputHandler(KMS_Charactor charactor, InputState inputState)
    {
        return null;
    }

    public virtual KMS_StatePattern Update(GameObject obj)
    {
        return null;
    }
}
