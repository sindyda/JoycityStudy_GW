using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    None,
    Type_Particle,
    Type_Cube,
}


public class KMS_Object : MonoBehaviour
{
    public bool inUse = false;
    public PoolType poolType = PoolType.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
