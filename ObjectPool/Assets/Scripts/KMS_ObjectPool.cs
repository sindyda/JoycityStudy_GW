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
            var obj = CreateObject<KMS_Particle>("Light_Particle");
            if (obj != null)
                obj.Init(5.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var obj = CreateObject<KMS_Cube>("Cube");
            if (obj != null)
                obj.Init();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0F))
            {
                if (hit.collider != null)
                {
                    hit.transform.gameObject.GetComponent<KMS_Cube>().inUse = false;
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }

    T CreateObject<T>(string prefabName)
    {
        T obj = gameObject.GetComponent<T>();

        for (int i = 0; i < objPool.Count; ++i)
        {
            var objData = objPool[i].GetComponent<T>();
            if (objData != null)
            {
                if (!objPool[i].inUse)
                {
                    return objData;
                }
            }
        }

        var newObject = Instantiate(Resources.Load(prefabName) as GameObject).GetComponent<T>();
        objPool.Add(newObject as KMS_Object);

        return newObject;
    }
}