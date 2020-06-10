using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool_soli : MonoBehaviour
{
    void Start()
    {

    }
    
    void Update()
    {
        animate();

        if(Input.GetKeyDown(KeyCode.N))
        {
            create(0, -10f, 0, 0.1f, 10);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            create(-10f, 0, 0.1f, 0, 10);
        }
    }

    void create(float x_, float y_, float xVel_, float yVel_, float lifeTime_)
    {
        for (int i = 0; i < POOL_SIZE; ++i)
        {
            if (particles[i] == null || (particles[i] != null && !particles[i].inUse()))
            {
                particles[i] = Instantiate(particle, Vector3.zero, Quaternion.identity);
                particles[i].init(x_, y_, xVel_, yVel_, lifeTime_);
                return;
            }
        }
    }

    void animate()
    {
        for (int i = 0; i < POOL_SIZE; ++i)
        {
            if(particles[i] != null)
                particles[i].animate();
        }
    }

    public Particle_soli particle;
    const int POOL_SIZE = 10;
    Particle_soli[] particles = new Particle_soli[POOL_SIZE];
}
