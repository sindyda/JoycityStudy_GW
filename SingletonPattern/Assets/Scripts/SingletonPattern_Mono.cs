using UnityEngine;

public class SingletonPattern_Mono : MonoBehaviour
{
    private SingletonPattern_Mono() { }
    private static SingletonPattern_Mono instance = null;
    public static SingletonPattern_Mono GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("해당 오브젝트가 없다");
        }

        return instance;
    }

    public void Awake()
    {
        instance = this;
    }

    public void Use()
    {
        Debug.Log("모노를 사용한 싱글톤");
    }

}
