using UnityEngine;

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
            // 캐릭터 상태창과 장비 변경때
            case Event.StatusChange:
            case Event.Equipment:
                Debug.Log("스테이터스 UI를 업데이트 합니다.");
                break;
        }
    }
}
