using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Cube : KMS_Object
{
    public void Init()
    {
        inUse = true;
        gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        //var obj = collision.gameObject.GetComponent<KMS_Cube>();
        inUse = false;
        gameObject.SetActive(false);
    }
}
