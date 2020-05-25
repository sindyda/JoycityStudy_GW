using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueManager_soli : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Audio_soli.playSound(1, 100);
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            Audio_soli.playSound(2, 70);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Audio_soli.update();
        }
    }
}
