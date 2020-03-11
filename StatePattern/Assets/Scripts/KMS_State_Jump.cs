using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_State_Jump : KMS_StatePattern
{
    float jumpCount = 3.0f;
    public override void Enter(GameObject obj)
    {
        jumpCount = 3.0f;
        Debug.Log("KMS_State_Jump Enter");
        obj.transform.SetPositionAndRotation(new Vector3(0, 5), Quaternion.identity);
    }

    public override KMS_StatePattern InputHandler(KMS_Charactor charactor, InputState inputState)
    {
        return null;
    }

    public override KMS_StatePattern Update(GameObject obj)
    {
        jumpCount -= Time.deltaTime * 2;
        if (jumpCount <= 0.0f)
            return new KMS_State_Stand();

        return null;
    }
}
