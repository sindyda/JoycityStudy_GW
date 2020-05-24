using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_FieldObject
{
    public bool isAttackEnable = false;
    public string objectName = "";

    public KMS_FieldObject(bool _isAttackEnable, string _objectName)
    {
        isAttackEnable = _isAttackEnable;
        objectName = _objectName;
    }
}
