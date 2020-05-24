using UnityEngine;

// 옵저버 패턴의 원형
public class KMS_ObserverPattern : MonoBehaviour
{
    public KMS_ObserverPattern nextOb = null;
    public UIType type;

    // 옵저버를 상속받는 클래스들은 다음 함수를 꼭 구현해야 한다
    public virtual void Notify(Event type)
    {
        // 데이터가 전달 되었을 때 수행해야 하는 일들을 진행할 수 있다
    }
}