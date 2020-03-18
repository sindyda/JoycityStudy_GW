using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor_Soli : MonoBehaviour
{
    public Actor_Soli()
    {
        currentSlapped_ = false;
    }

    public void update()
    {
        if (wasSlapped())
        {
            facing_.slap();
        }
    }

    public void face(Actor_Soli actor)
    {
        facing_ = actor;
    }

    public void swap()
    {
        currentSlapped_ = nextSlapped_;
        nextSlapped_ = false;
    }
   
    public void slap()
    {
        Debug.Log(gameObject.name + "가 맞음");
        nextSlapped_ = true;
    }

    public bool wasSlapped()
    {
        return currentSlapped_;
    }

    private Actor_Soli facing_;

    private bool currentSlapped_;
    private bool nextSlapped_;
}