using UnityEngine;

public class SkillManager : SingletonPattern_IsA_Mono<SkillManager>
{
    public void Use()
    {
        Debug.Log("모노 제너릭을 사용한 싱글톤");
    }
}
