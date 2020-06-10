using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_Object : MonoBehaviour
{
    float xVel, yVel = 0;
    float timeLeft = 0;

    public void Create(float x, float y, float xVel, float yVel, float timeLeft)
    {
        transform.localPosition = new Vector3(x, y);
        this.xVel = xVel;
        this.yVel = yVel;
        this.timeLeft = timeLeft;

        gameObject.SetActive(true);
    }

    public void Animate()
    {
        if (InUse() == false)
        {
            return;
        }

        transform.localPosition += new Vector3(xVel, yVel);

        timeLeft -= Time.deltaTime;
    }

    public bool InUse()
    {
        return timeLeft > 0;
    }

}
