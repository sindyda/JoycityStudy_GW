using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KMS_FlyweightPattern : MonoBehaviour
{
    const int mapSizeX = 16;
    const int mapSizeY = 16;

    KMS_FieldObject[,] fieldObjectArray = new KMS_FieldObject[mapSizeX, mapSizeY];

    KMS_FieldObject fieldIsle = new KMS_FieldObject(2, 2, true, "Isle");
    KMS_FieldObject fieldGuildDepot = new KMS_FieldObject(2, 2, false, "GuildDepot");
    KMS_FieldObject fieldMonster = new KMS_FieldObject(3, 3, true, "Monster");
    KMS_FieldObject fieldAircraftMonster = new KMS_FieldObject(3, 3, true, "aircraft");

    private void Start()
    {
        for (int i = 0; i < mapSizeX; ++i)
        {
            for (int j = 0; j < mapSizeY; ++j)
            {
                switch (Random.Range(0, 4))
                {
                    case 0:
                        fieldObjectArray[i, j] = fieldIsle;
                        break;
                    case 1:
                        fieldObjectArray[i, j] = fieldGuildDepot;
                        break;
                    case 2:
                        fieldObjectArray[i, j] = fieldMonster;
                        break;
                    case 3:
                        fieldObjectArray[i, j] = fieldAircraftMonster;
                        break;
                }
            }
        }

        for (int i = 0; i < mapSizeX; ++i)
        {
            for (int j = 0; j < mapSizeY; ++j)
            {
                GameObject obj = Instantiate(Resources.Load(fieldObjectArray[i, j].objectName, typeof(GameObject))) as GameObject;
                obj.transform.localPosition = new Vector3(i, j, 0);
            }
        }
    }
}
