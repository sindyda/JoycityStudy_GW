using System;

public class SingletonPattern_IsA<T> where T : class
{
    private static T instance = null;
    public static T Instnace
    {
        get
        {
            if (instance == null)
            {
                instance = Activator.CreateInstance(typeof(T)) as T;
            }
            return instance;
        }
    }
}
