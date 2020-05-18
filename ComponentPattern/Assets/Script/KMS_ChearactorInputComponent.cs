using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_ChearactorInputComponent : KMS_InputComponent
{
    public override void Update(KMS_ComponentsPattern component)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            component.x -= Time.deltaTime * 10;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            component.x += Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (component.state == CHAR_STATE.GROUND)
                component.state = CHAR_STATE.JUMP;
        }
    }

}
