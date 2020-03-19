using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBuffrerPatternManager_Soli : MonoBehaviour
{
    Stage_Soli stage = new Stage_Soli();

    public Actor_Soli one;
    public Actor_Soli two;
    public Actor_Soli three;
    
    void Start()
    {
        one.face(two);
        two.face(three);
        three.face(one);

        stage.add(one, 0);
        stage.add(two, 1);
        stage.add(three, 2);

        one.slap();
    }

    private void Update()
    {
        stage.update();
    }
}
