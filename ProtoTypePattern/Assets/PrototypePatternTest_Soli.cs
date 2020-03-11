using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypePatternTest_Soli : MonoBehaviour
{
    private int ghostNumber = 0;
    private int demonNumber = 0;

    Monster_Soli ghostPrototype = null;
    Spawner_Soli ghostSpawner = null;

    Monster_Soli demonPrototype = null;
    Spawner_Soli demonSpawner = null;

    void Start()
    {
        ghostPrototype = new Ghost_Soli(100, 3);
        ghostSpawner = new Spawner_Soli(ghostPrototype);

        demonPrototype = new Demon_Soli(30, 5);
        demonSpawner = new Spawner_Soli(demonPrototype);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            ++ghostNumber;
            var tempGhost = ghostSpawner?.spawnMonster();
            Debug.Log(ghostNumber + "번째 고오오오오호슽 생성 / 체력 : " + tempGhost?.health + " /스피드 : " + tempGhost?.speed);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            ++demonNumber;
            var tempGhost = demonSpawner?.spawnMonster();
            Debug.Log(demonNumber + "번째 악마!! 생성 / 체력 : " + tempGhost?.health + " /스피드 : " + tempGhost?.speed);
        }
    }
}
