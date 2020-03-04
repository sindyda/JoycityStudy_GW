using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Ghost : KMS_Monster
{
    public KMS_Ghost(int hp, int spd, int x, int y)
    {
        health = hp;
        speed = spd;
        positionX = x;
        positionY = y;
    }

    public override KMS_Monster Clone()
    {
        return new KMS_Ghost(health, speed, positionX, positionY);
    }
}
