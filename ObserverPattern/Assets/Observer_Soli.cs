using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType_Soli
{
    EventType_Soli_A,
    EventType_Soli_B,
    EventType_Soli_C,
}

public class Observer_Soli
{
    public virtual void onNotify(Subject_Soli entity, EventType_Soli eventType)
    { }
}

public class Achievement_Soli : Observer_Soli
{
    public override void onNotify(Subject_Soli entity, EventType_Soli eventType)
    {
        switch(eventType)
        {
            case EventType_Soli.EventType_Soli_A:
                entity.achivementText.text = "A 달성";
                break;
            case EventType_Soli.EventType_Soli_B:
                entity.achivementText.text = "B 달성";
                break;
            case EventType_Soli.EventType_Soli_C:
                entity.achivementText.text = "C 달성";
                break;
        }
    }
}


public class Audio_Soli : Observer_Soli
{
    public override void onNotify(Subject_Soli entity, EventType_Soli eventType)
    {
        switch (eventType)
        {
            case EventType_Soli.EventType_Soli_A:
                entity.audioText.text = "A 아ㅏㅏㅏㅏㅏㅏㅏㅏㅏ";
                break;
            case EventType_Soli.EventType_Soli_B:
                entity.audioText.text = "B 삐ㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣ";
                break;
            case EventType_Soli.EventType_Soli_C:
                entity.audioText.text = "C 씨ㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣ";
                break;
        }
    }
}

