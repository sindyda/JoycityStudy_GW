using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPattern_Property
{
    private SingletonPattern_Property() { }

    private static SingletonPattern_Property instance = null;
    public static SingletonPattern_Property Instance
    {
        get
        {
            if (instance == null)
                instance = new SingletonPattern_Property();
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    public void Use()
    {
        Debug.Log("프로퍼티를 사용한 싱글톤");
    }

}
