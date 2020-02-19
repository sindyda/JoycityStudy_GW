using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int posX = 0;
    public int posY = 0;

    public CommandPattern MoveTo(int x, int y)
    {
        posX = x;
        posY = y;

        transform.localPosition = new Vector3(posX, 0, posY);

        return new MoveUnitCommand(this, posX, posY);
    }
}
