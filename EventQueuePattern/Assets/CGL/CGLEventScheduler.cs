using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGL
{
    public struct CGLEvent
    {

        public Action onEvent;
    }

    public class CGLEventQueue
    {
        List<CGLEvent> queues1 = new List<CGLEvent>();
        List<CGLEvent> queues2 = new List<CGLEvent>();

        float remainTime = 1.0f;
        bool isFirst = false;

        public void AddEvent(CGLEvent ev)
        {
            if (isFirst)
            {
                queues1.Add(ev);
            }
            else
            {
                queues2.Add(ev);
            }

        }

        public void update(float deltaTime)
        {
            remainTime -= deltaTime;
            if(remainTime > 0)
            {
                return;
            }

            remainTime = 1f;

            CGLEvent[] itemarray = null;
            if (isFirst)
            {
                itemarray = new CGLEvent[queues2.Count];
                queues2.CopyTo(itemarray);
                queues2.Clear();
            }
            else
            {
                itemarray = new CGLEvent[queues1.Count];
                queues1.CopyTo(itemarray);
                queues1.Clear();
            }

            if(itemarray == null)
            {
                return;
            }

            int length = itemarray.Length;
            for (int i = 0; i < length; i++)
            {
                itemarray[i].onEvent();
            }

            isFirst = !isFirst;
        }
    }

    public class CGLEventScheduler : MonoBehaviour
    {
        CGLEventQueue eventQueue = new CGLEventQueue();

        public void ForkEvent(CGLEvent sender)
        {
            eventQueue.AddEvent(sender);
        }

        private void Update()
        {
            float deltatime = Time.deltaTime;
            eventQueue.update(deltatime);
        }
    }

}

