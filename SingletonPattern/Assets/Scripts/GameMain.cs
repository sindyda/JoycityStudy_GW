using UnityEngine;

public class GameMain : MonoBehaviour
{
    void Start()
    {
        // 가장 기본의 싱글톤
        SingletonPattern.GetInstance().Use();
        // 모노를 활용한 싱글톤
        SingletonPattern_Mono.GetInstance().Use();
        // 프로퍼티를 사용한 싱글톤
        SingletonPattern_Property.Instance.Use();

        // 제네릭 싱글톤(모노X)
        ItemManager.Instnace.Use();

        // 제네릭 싱글톤(모노)
        SkillManager.Insatnce.Use();
    }
}
