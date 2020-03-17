using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Equip_Sword : KMS_StatePattern
{
    GameObject sword;

    public override void Enter(GameObject obj)
    {
        Debug.Log("KMS_Equip_Sword Enter");

        sword = GameObject.Instantiate(Resources.Load("Sword") as GameObject);
        sword.transform.parent = obj.transform;
        obj.GetComponent<KMS_Charactor>().weapon = sword.GetComponent<KMS_Weapon_Sword>();
    }

    public override KMS_StatePattern InputHandler(KMS_Charactor charactor, InputState inputState)
    {
        if (inputState == InputState.INPUT_CHANGE_WAEPON_GUN)
            return new KMS_Equip_Gun();

        return null;
    }

    public override KMS_StatePattern Update(GameObject obj)
    {
        return null;
    }

    public override void Exit(GameObject obj)
    {
        GameObject.Destroy(sword);
    }
}
