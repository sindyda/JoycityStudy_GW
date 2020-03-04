using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_GameManager : MonoBehaviour
{
    KMS_ProtoTypePattern spawnMonster;
    KMS_ProtoTypePattern spawnMonster2;

    List<KMS_Monster> baseGhost = new List<KMS_Monster>();
    List<KMS_Monster> baseDemon = new List<KMS_Monster>();

    // Start is called before the first frame update
    void Start()
    {
        spawnMonster = new KMS_ProtoTypePattern(spawnGhost);
        spawnMonster2 = new KMS_ProtoTypePattern(spawnDemon);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var monster = spawnMonster.SpawnMonster();
            baseGhost.Add(monster);
            Debug.Log("Create Ghost");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (baseGhost.Count > 0)
            {
                baseGhost.Add(baseGhost[0].Clone());
                Debug.Log("Create clone Ghost");
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            baseDemon.Add(spawnMonster2.SpawnMonster());
            Debug.Log("Create Demon");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (baseDemon.Count > 0)
            {
                baseDemon.Add(baseDemon[0].Clone());
                Debug.Log("Create clone Demon");
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < baseGhost.Count; ++i)
            {
                Debug.Log(baseGhost[i] + " " + i);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < baseDemon.Count; ++i)
            {
                Debug.Log(baseDemon[i] + " " + i);
            }
        }
    }

    public KMS_Monster spawnGhost()
    {
        return new KMS_Ghost(10, 10, 10, 10);
    }

    public KMS_Monster spawnDemon()
    {
        return new KMS_Demon(20, 20, 20, 20);
    }


}
