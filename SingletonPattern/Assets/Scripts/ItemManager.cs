using UnityEngine;

public class ItemManager : SingletonPattern_IsA<ItemManager>
{ 
    public void Use()
    {
        Debug.Log("제너릭을 사용한 싱글톤");
    }
}
