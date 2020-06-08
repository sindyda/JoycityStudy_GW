using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_ObjectPool : MonoBehaviour
{
    List<KMS_Object> objPool = new List<KMS_Object>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < objPool.Count; ++i)
            {
                if (objPool[i].poolType == PoolType.Type_Particle)
                {
                    if (!objPool[i].inUse)
                    {
                        objPool[i].GetComponent<KMS_Particle>().Init(5.0f);
                        return;
                    }
                }
            }
            KMS_Particle obj = Instantiate(Resources.Load("Light_Particle") as GameObject).GetComponent<KMS_Particle>();
            obj.poolType = PoolType.Type_Particle;
            objPool.Add(obj);
            obj.Init(5.0f);
        }
    }
}