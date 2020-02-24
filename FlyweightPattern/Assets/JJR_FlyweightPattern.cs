using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
public class JJR_Terrain
{
    const int MAX_PROPERTIES_LAYER = 10000;
    private List<int> layer = new List<int>();
    public JJR_Terrain()
    {
        for (int i = 0; i < MAX_PROPERTIES_LAYER; ++i)
        {
            layer.Add(i);
        }
    }

    public long LayerSum()
    {
        int totalSum = 0;
        for (int i = 0; i < layer.Count; ++i)
        {
            totalSum += layer[i];
        }

        return totalSum;
    }
}

public class JJR_ChildClass : JJR_Terrain
{
    Vector3 position = new Vector3(0, 0, 0);
    public JJR_ChildClass()
    {

    }
}

public class JJR_FlyweightClass
{
    JJR_Terrain commonTerrain = null;

    public JJR_FlyweightClass(JJR_Terrain commonTerrain)
    {
        this.commonTerrain = commonTerrain;
    }

    public long LayerSum()
    {
        if (commonTerrain != null)
        {
            return commonTerrain.LayerSum();
        }

        return 0;
    }
}

public class JJR_FlyweightPattern : MonoBehaviour
{
    public UnityEngine.UI.Text text = null;
    const int CREATE_MEMORY_COUNT = 10000;

    List<JJR_ChildClass> childList = new List<JJR_ChildClass>();
    List<JJR_FlyweightClass> flyweightList = new List<JJR_FlyweightClass>();

    JJR_Terrain commonTerrain = new JJR_Terrain();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            childList.Clear();
            flyweightList.Clear();

            float befTime = Time.realtimeSinceStartup;

            for (int i = 0; i < CREATE_MEMORY_COUNT; ++i)
            {
                childList.Add(new JJR_ChildClass());
            }

            if (text != null)
            {
                text.text = string.Format("Time : {0}", Time.realtimeSinceStartup - befTime);
            }
        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
            childList.Clear();
            flyweightList.Clear();

            float befTime = Time.realtimeSinceStartup;

            for (int i = 0; i < CREATE_MEMORY_COUNT; ++i)
            {
                flyweightList.Add(new JJR_FlyweightClass(commonTerrain));
            }
            if (text != null)
            {
                text.text = string.Format("Time : {0}", Time.realtimeSinceStartup - befTime);
            }
        }
    }
}
