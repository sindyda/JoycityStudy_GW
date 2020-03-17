using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputState
{
    INPUT_PRESS_DOWN,
    INPUT_RELEASE_DOWN,
    INPUT_PRESS_UP,
    INPUT_PRESS_ATTACK,
    INPUT_RELEASE_ATTACK,
    INPUT_CHANGE_WAEPON_GUN,
    INPUT_CHANGE_WEAPON_SWORD,
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

    public virtual void Exit(GameObject obj)
    {
        Debug.Log("KMS_State Exit");
    }
}
