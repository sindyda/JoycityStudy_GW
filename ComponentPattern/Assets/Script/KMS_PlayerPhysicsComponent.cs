using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_PlayerPhysicsComponent : KMS_PhysicsComponent
{
    float jumpPower = 3.0f;
    float startJumpPoint = 0.0f;
    public override void Update(KMS_ComponentsPattern component)
    {
        float x = component.x;
        float y = component.y;
        float z = 0.0f;

        switch (component.state)
        {
            case CHAR_STATE.GROUND:
                startJumpPoint = 0.0f;
                break;
            case CHAR_STATE.JUMP:
                {
                    if (startJumpPoint == 0.0f)
                    {
                        startJumpPoint = y;
                    }


                    if (jumpPower <= 0.0f)
                    {
                        // 다운
                        y -= Time.deltaTime * 5.0f;
                    }
                    else
                    {
                        // 업 
                        float t = Time.deltaTime * 5.0f;
                        y += t;
                        jumpPower -= t;
                    }

                    if (y <= 0.0f)
                    {
                        component.state = CHAR_STATE.GROUND;
                        startJumpPoint = 0.0f;
                        jumpPower = 3.0f;
                    }

                    component.y = y;
                }
                break;
        }

        UpdatePosition(component, x, y, z);
    }

    public void UpdatePosition(KMS_ComponentsPattern component, float x, float y, float z)
    {
        component.gameObject.transform.localPosition = new Vector3(x, y, z);
        Debug.Log(x);
    }
}
