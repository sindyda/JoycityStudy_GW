using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_UpDownActionComponent : JJR_ActionComponent
{
    enum DIRECTION_TYPE
    {
        UP,
        DOWN
    }
    public float speed = 5.0f;

    DIRECTION_TYPE direction = DIRECTION_TYPE.UP;
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

        float goalPositionY = Mathf.Abs(positionTable[positionIndex]);

        switch (direction)
        {
            case DIRECTION_TYPE.UP:
                {
                    if (goalPositionY < obj.transform.localPosition.y)
                    {
                        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, goalPositionY, obj.transform.localPosition.z);
                        ++positionIndex;
                        direction = DIRECTION_TYPE.DOWN;
                        break;
                    }

                    obj.transform.localPosition += new Vector3(0, Time.deltaTime * speed, 0);
                    break;
                }
            case DIRECTION_TYPE.DOWN:
                {
                    goalPositionY *= -1;
                    if (goalPositionY > obj.transform.localPosition.y)
                    {
                        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, goalPositionY, obj.transform.localPosition.z);
                        ++positionIndex;
                        direction = DIRECTION_TYPE.UP;
                        break;
                    }

                    obj.transform.localPosition += new Vector3(0, -Time.deltaTime * speed, 0);
                    break;
                }
        }

    }

    override public void SendAddSpeed(float addSpeed)
    {
        speed += addSpeed;
    }
}
