using System.Collections.Generic;
using UnityEngine;

public class KMS_GameManager : MonoBehaviour
{
    // 프로토 타입 패턴으로 스폰 생성
    KMS_ProtoTypePattern spawnMonster;
    KMS_ProtoTypePattern spawnMonster2;

    // 각각의 몬스터를 저장할 컨테이너
    List<KMS_Monster> baseGhost = new List<KMS_Monster>();
    List<KMS_Monster> baseDemon = new List<KMS_Monster>();

    void Start()
    {
        // 콜백 메시지를 등록
        spawnMonster = new KMS_ProtoTypePattern(spawnGhost);
        spawnMonster2 = new KMS_ProtoTypePattern(spawnDemon);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // spawnGhost 함수가 호출 되서 기본 Ghost를 하나 생성
            var monster = spawnMonster.SpawnMonster();
            // 해당 부분을 저장한다
            baseGhost.Add(monster);
            Debug.Log("Create Ghost");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (baseGhost.Count > 0)
            {
                // 이 부분이 복사 만들어 놓은 첫번째(순서는 중요치 않음)의 클론 생성해서 다시 보관
                baseGhost.Add(baseGhost[0].Clone());
                Debug.Log("Create clone Ghost");
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            // spawnDemon 함수가 호출되서 Demon하나 생성
            baseDemon.Add(spawnMonster2.SpawnMonster());
            Debug.Log("Create Demon");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (baseDemon.Count > 0)
            {
                // 클론 생성해서 저장
                baseDemon.Add(baseDemon[0].Clone());
                Debug.Log("Create clone Demon");
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            // 지금까지 만든 데이터 출력
            for (int i = 0; i < baseGhost.Count; ++i)
            {
                Debug.Log(baseGhost[i] + " " + i);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            // 지금까지 만든 데이터 출력
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
