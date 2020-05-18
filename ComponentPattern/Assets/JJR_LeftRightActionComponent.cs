using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_LeftRightActionComponent : JJR_ActionComponent
{
    enum DIRECTION_TYPE
    {
        LEFT,
        RIGHT
    }
    public float speed = 5.0f;

    DIRECTION_TYPE direction = DIRECTION_TYPE.LEFT;
    float[] positionTable = new float[] { 2.0f, 1.5f, 1.0f, 0.5f, 0.25f };
    int positionIndex = 0;

    override public void UpdateAction(JJR_Object obj)
    {
        if (obj == null)
        {
            return;
        }

        if (positionIndex >= positionTable.Length)
        {
            positionIndex = 0;
        }

        float goalPositionX = Mathf.Abs(positionTable[positionIndex]);

        switch (direction)
        {
            case DIRECTION_TYPE.LEFT:
                {
                    goalPositionX *= -1;
                    if (goalPositionX > obj.transform.localPosition.x)
                    {
                        obj.transform.localPosition = new Vector3(goalPositionX, obj.transform.localPosition.y, obj.transform.localPosition.z);
                        ++positionIndex;
                        direction = DIRECTION_TYPE.RIGHT;
                        break;
                    }

                    obj.transform.localPosition += new Vector3(-Time.deltaTime * speed, 0, 0);
                    break;
                }
            case DIRECTION_TYPE.RIGHT:
                {
                    if (goalPositionX < obj.transform.localPosition.x)
                    {
                        obj.transform.localPosition = new Vector3(goalPositionX, obj.transform.localPosition.y, obj.transform.localPosition.z);
                        ++positionIndex;
                        direction = DIRECTION_TYPE.LEFT;
                        break;
                    }

                    obj.transform.localPosition += new Vector3(Time.deltaTime * speed, 0, 0);
                    break;
                }
        }

    }

    override public void SendAddSpeed(float addSpeed)
    {
        speed += addSpeed;
    }
}
