using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_FieldObject
{
    public int sizeX = 0;
    public int sizeY = 0;
    public bool isAttackEnable = false;
    public string objectName = "";

    public KMS_FieldObject(int _sizeX, int _sizeY, bool _isAttackEnable, string _objectName)
    {
        sizeX = _sizeX;
        sizeY = _sizeY;
        isAttackEnable = _isAttackEnable;
        objectName = _objectName;
    }
}
