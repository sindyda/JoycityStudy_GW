using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypePatternTest_Soli : MonoBehaviour
{
    public int ghostNumber = 1;
    public int demonNumber = 1;

    Monster_Soli ghostPrototype = null;
    Spawner_Soli ghostSpawner = null;

    Monster_Soli demonPrototype = null;
    Spawner_Soli demonSpawner = null;

    void Start()
    {
        ghostPrototype = new Ghost_Soli(15, 3);
        ghostSpawner = new Spawner_Soli(ghostPrototype);

        demonPrototype = new Demon_Soli(40, 5);
        demonSpawner = new Spawner_Soli(demonPrototype);

        for (int i = 0; i < ghostNumber; ++i)
        {
            var tempGhost = ghostSpawner.spawnMonster();
            Debug.Log(i + 1 + "번째 고슽 / 체력 : " + tempGhost.health + " /스피드 : " + tempGhost.speed);
        }

        for (int i = 0; i < demonNumber; ++i)
        {
            var tempDemon = demonSpawner.spawnMonster();
            Debug.Log(i + 1 + "번째 악마? / 체력 : " + tempDemon.health + " /스피드 : " + tempDemon.speed);
        }
    }
}
