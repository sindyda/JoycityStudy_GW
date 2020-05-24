using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임에서 넘어 올 수 있는 이벤트들
public enum Event
{
    StatusChange,
    Equipment,
    GetItem,
}

public class KMS_Subject
{
    KMS_ObserverPattern head = null;

    // 메시지를 받을 UI
    public void AddObserver(KMS_ObserverPattern ob)
    {
        ob.nextOb = head;
        head = ob;
    }

    // 더이상 메시지를 받지 않을 UI
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

    // 메시지 전달
    public void Message(Event type)
    {
        KMS_ObserverPattern ob = head;
        while (ob != null)
        {
            ob.Notify(type);
            ob = ob.nextOb;
        }
    }
}
