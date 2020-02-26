using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_UI_Equipment : KMS_ObserverPattern
{
    private void Start()
    {
        type = UIType.Status;
    }

    public override void Notify(Event type)
    {
        switch (type)
        {
            case Event.Equipment:
                Debug.Log("장비 UI를 업데이트 합니다.");
                break;
        }
    }
}
