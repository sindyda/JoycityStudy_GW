using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_soli : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Particle_soli()
    {
        framesLeft = 0;
    }

    public void init(float x_, float y_, float xVel_, float yVel_, float lifeTime_)
    {
        x = x_;
        y = y_;
        xVel = xVel_;
        yVel = yVel_;
        framesLeft = lifeTime_;
    }

    public void animate()
    {
        if (!inUse())
            return;
        
        framesLeft -= Time.deltaTime;
        x += xVel;
        y += yVel;

        transform.localPosition = new Vector3(x, y, 0);
    }

    public bool inUse()
    {
        return framesLeft > 0;
    }

    private float framesLeft;
    private float x, y;
    private float xVel, yVel;
}
