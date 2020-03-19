using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Equip_Gun : KMS_StatePattern
{
    GameObject gun = null;

    public override void Enter(GameObject obj)
    {
        Debug.Log("KMS_Equip_Gun Enter");

        gun = GameObject.Instantiate(Resources.Load("Gun") as GameObject);
        gun.transform.parent = obj.transform;
        obj.GetComponent<KMS_Charactor>().weapon = gun.GetComponent<KMS_Weapon_Gun>();
    }

    public override KMS_StatePattern InputHandler(KMS_Charactor charactor, InputState inputState)
    {
        if (inputState == InputState.INPUT_CHANGE_WEAPON_SWORD)
            return new KMS_Equip_Sword();

        return null;
    }

    public override KMS_StatePattern Update(GameObject obj)
    {
        return null;
    }

    public override void Exit(GameObject obj)
    {
        if (gun != null)
            GameObject.Destroy(gun);
    }
}
