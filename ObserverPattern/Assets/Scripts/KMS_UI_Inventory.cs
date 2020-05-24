using UnityEngine;

public class KMS_UI_Inventory : KMS_ObserverPattern
{
    private void Start()
    {
        type = UIType.Status;
    }

    public override void Notify(Event type)
    {
        switch (type)
        {
            // 아이템 획득과 장비 변경때
            case Event.Equipment:
            case Event.GetItem:
                Debug.Log("인벤토리 UI를 업데이트 합니다.");
                break;
        }
    }
}
