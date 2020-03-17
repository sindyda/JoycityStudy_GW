using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_State_Attack : KMS_StatePattern
{
    public override void Enter(GameObject obj)
    {
        Debug.Log("KMS_State_Attack Enter");

        if (obj.GetComponent<KMS_Charactor>().weapon != null)
        {
            obj.GetComponent<KMS_Charactor>().weapon.isAttack = true;
        }
    }

    public override KMS_StatePattern InputHandler(KMS_Charactor charactor, InputState inputState)
    {
        if (inputState == InputState.INPUT_RELEASE_ATTACK)
            return new KMS_State_Stand();
        if (inputState == InputState.INPUT_CHANGE_WAEPON_GUN)
            return new KMS_State_Stand();
        if (inputState == InputState.INPUT_CHANGE_WEAPON_SWORD)
            return new KMS_State_Stand();

        return null;
    }

    public override KMS_StatePattern Update(GameObject obj)
    {
        return null;
    }

    public override void Exit(GameObject obj)
    {
        if (obj.GetComponent<KMS_Charactor>().weapon != null)
        {
            obj.GetComponent<KMS_Charactor>().weapon.isAttack = false;
        }
    }
}