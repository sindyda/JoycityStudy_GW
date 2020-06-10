using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Particle : KMS_Object
{
    float lifeTime = 0;

    public void Init(float playTime)
    {
        lifeTime = playTime;
        inUse = true;
        this.gameObject.SetActive(true);
    }

    public void Update()
    {
        if(inUse)
        {
            lifeTime -= Time.deltaTime;
            if( lifeTime < 0.0f )
            {
                inUse = false;
                gameObject.SetActive(false);
            }
        }
    }
}
