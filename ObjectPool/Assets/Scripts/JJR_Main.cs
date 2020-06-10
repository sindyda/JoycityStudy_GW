using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_ObjectPool
{
    JJR_Object originObject = null;
    const int POOL_SIZE = 100;

    JJR_Object[] objects = new JJR_Object[POOL_SIZE];

    public void SetOrginObject(JJR_Object originObject)
    {
        this.originObject = originObject;
    }

    public void Create(float x, float y, float xVel, float yVel, float timeLeft)
    {
        for (int i = 0; i < objects.Length; ++i)
        {
            if (objects[i] == null)
            {
                objects[i] = GameObject.Instantiate(originObject);
            }

            if (objects[i] != null && objects[i].InUse() == false)
            {
                objects[i].Create(x, y, xVel, yVel, timeLeft);
                break;
            }

        }

    }

    public void Animate()
    {
        for (int i = 0; i < objects.Length; ++i)
        {
            if (objects[i] != null)
            {
                objects[i].Animate();

                if (objects[i].InUse() == false)
                {
                    objects[i].gameObject.SetActive(false);
                }
            }
        }

    }
}


public class JJR_Main : MonoBehaviour
{
    const int CREATE_OBJECT_NUM = 3;
    public JJR_Object originObject = null;

    JJR_ObjectPool objectPool = new JJR_ObjectPool();

    // Start is called before the first frame update
    void Start()
    {
        originObject.gameObject.SetActive(false);
        objectPool.SetOrginObject(originObject);
    }

    // Update is called once per frame
    void Update()
    {
        objectPool.Animate();
        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < CREATE_OBJECT_NUM; ++i)
            {
                objectPool.Create(0, 0, Random.Range(-0.02f, 0.02f), Random.Range(-0.02f, 0.02f), Random.Range(0.5f, 2.0f));
            }
        }
    }
}
