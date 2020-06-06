using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPattern
{
    private SingletonPattern() { }
    private static SingletonPattern instance = null;
    public static SingletonPattern GetInstance()
    {
        if (instance == null)
        {
            instance = new SingletonPattern();
        }

        return instance;
    }

    public void Use()
    {
        Debug.Log("일반적인 싱글톤");
    }
}
