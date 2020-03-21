using LeeChangi;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LCGTester : MonoBehaviour
{
    public ThreadSafeManager manager = new ThreadSafeManager();
    void Start()
    {
       
    }
    int index = 0;
    float updateTime = 0;
    float firstupdatetime = 0;
    float secondupdatetime = 0;
    float thirdupdatetime = 0;

    
    // Update is called once per frame
    void Update()
    {

        //currentTime += Time.deltaTime;
        

        //updateTime += Time.deltaTime;
        //for (int i = 0; i < 100; i++)
        //{
        //    index++;
        //    ProcessWorker worker = new ProcessWorker(index, (long)currentTime + 2);
        //    Thread t = new Thread(new ParameterizedThreadStart(AddWorker));
        //    t.Start(worker);
        //}

        //if (updateTime > 1.0f)
        //{
        //    updateTime = 0;
        //    manager.UpdateLogic((long)currentTime);

            
        //}
        
    }

    private float currentTime = 0;
    private void AddWorker(object randomValue)
    {
        if(manager != null)
        {
            manager.AddWorker((ProcessWorker)(randomValue));
        }
    }
}
