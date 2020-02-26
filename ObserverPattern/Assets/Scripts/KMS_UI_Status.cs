using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KMS_UI_Status : KMS_ObserverPattern
{
    private void Start()
    {
        type = UIType.Status;
    }

    public override void Notify(Event type)
    {
        switch (type)
        {
            case Event.StatusChange:
            case Event.Equipment:
                Debug.Log("스테이터스 UI를 업데이트 합니다.");
                break;
        }
    }
}
