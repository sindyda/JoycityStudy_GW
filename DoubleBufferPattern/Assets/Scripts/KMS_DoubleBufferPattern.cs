using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_DoubleBufferPattern
{
    KMS_Actor[] actors = new KMS_Actor[3];

    public void add(KMS_Actor actor, int index)
    {
        actors[index] = actor;
    }

    public void update()
    {
        for (int i = 0; i < 3; ++i)
        {
            actors[i].update();
        }

        for (int i = 0; i < 3; ++i)
        {
            actors[i].swap();
        }
    }
}

public class KMS_Actor
{
    public string name;

    public KMS_Actor(string actorName)
    {
        currentSlapped = false;
        name = actorName;
    }
    public void swap()
    {
        currentSlapped = nextSlapped;
        nextSlapped = false;
    }
    public virtual void update()
    {

    }

    public void slap()
    {
        currentSlapped = true;
        Debug.Log(name + "을때림");
    }

    public bool wasSlapped()
    {
        return currentSlapped;
    }

    bool currentSlapped;
    bool nextSlapped;
}

public class KMS_Comedian : KMS_Actor
{
    public KMS_Comedian(string actorName) : base(actorName)
    {
        name = actorName;
    }
    public void face(KMS_Actor actor)
    {
        facing = actor;
    }
    public override void update()
    {
        if (wasSlapped())
        {
            Debug.Log(name + "이 맞음");
            facing.slap();
        }
    }

    KMS_Actor facing;
}

