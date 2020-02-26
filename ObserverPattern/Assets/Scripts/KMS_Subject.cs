using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Event
{
    StatusChange,
    Equipment,
    GetItem,
}

public class KMS_Subject
{
    KMS_ObserverPattern head = null;

    public void AddObserver(KMS_ObserverPattern ob)
    {
        ob.nextOb = head;
        head = ob;
    }

    public void RemoveObserver(KMS_ObserverPattern ob)
    {
        if (head == ob)
        {
            head = ob.nextOb;
            ob.nextOb = null;
            return;
        }

        KMS_ObserverPattern current = head;
        while (current != null)
        {
            if (current.nextOb == ob)
            {
                current.nextOb = ob.nextOb;
                ob.nextOb = null;
                return;
            }
            current = current.nextOb;
        }
    }

    public void notify(Event type)
    {
        KMS_ObserverPattern ob = head;
        while (ob != null)
        {
            ob.Notify(type);
            ob = ob.nextOb;
        }
    }
}
