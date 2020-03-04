using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate KMS_Monster SpawnCallBack();

public class KMS_ProtoTypePattern
{
    SpawnCallBack spawnCallBack = null;

    public KMS_ProtoTypePattern(SpawnCallBack callBack)
    {
        spawnCallBack = new SpawnCallBack(callBack);
    }

    public virtual KMS_Monster SpawnMonster()
    {
        return spawnCallBack();
    }
}