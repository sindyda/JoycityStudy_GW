using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Monster
{
    public int health;
    public int speed;

    public int positionX;
    public int positionY;

    public virtual KMS_Monster Clone()
    {
        return new KMS_Monster();
    }
}
