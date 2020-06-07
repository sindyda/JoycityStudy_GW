using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGL
{

    public class CGLEventQueueSample : MonoBehaviour
    {
        public CGLEventScheduler scheduler;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Event1()
        {
            scheduler?.ForkEvent(new CGLEvent()
            {
                onEvent = () =>
                {
                    Debug.Log("Event1");
                }
            });
        }

        public void Event2()
        {
            scheduler?.ForkEvent(new CGLEvent()
            {
                onEvent = () =>
                {
                    Debug.Log("Event2");
                }
            });
        }
    }

}
