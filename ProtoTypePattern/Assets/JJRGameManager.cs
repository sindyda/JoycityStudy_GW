using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJRGameManager : MonoBehaviour
{
    public GameObject startObject = null;
    JJR_Spawner spawner = new JJR_Spawner();
    List<JJR_ProtoType> objectList = new List<JJR_ProtoType>();
    // Start is called before the first frame update
    void Start()
    {
        objectList.Add(new JJR_ProtoType(startObject, new List<Vector3>(), new List<Vector3>(), new List<Vector3>()));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int objCount = objectList.Count;
            if (objCount > 0 && startObject != null)
            {
                var lastObject = objectList[objCount - 1];

                int random = Random.Range(0, 3);
                if (random == 0)
                {
                    objectList.Add(spawner.spawnMove(lastObject));
                }
                else if (random == 1)
                {
                    objectList.Add(spawner.spawnScale(lastObject));
                }
                else if (random == 2)
                {
                    objectList.Add(spawner.spawnRotation(lastObject));
                }
            }
        }


        for (int i = 0; i < objectList.Count; ++i)
        {
            if (objectList[i] != null)
            {
                objectList[i].Update();
            }
        }
    }

    
}
