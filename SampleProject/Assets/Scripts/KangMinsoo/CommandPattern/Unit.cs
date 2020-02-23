using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int posX = 0;
    public int posY = 0;
    public float scaleX = 1.0f;
    public float scaleY = 1.0f;

    public void MoveTo(int x, int y)
    {
        posX = x;
        posY = y;

        transform.localPosition = new Vector3(posX, 0, posY);
    }

    public void ScaleTo(float x, float y)
    {
        scaleX = x;
        scaleY = y;

        transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
    }
}
