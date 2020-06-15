using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_soli : MonoBehaviour
{
    public void init(Grid_soli grid, float x, float y)
    {
        grid_ = grid;
        x_ = x;
        y_ = y;

        prev_ = null;
        next_ = null;

        grid_.add(this);
    }

    public void move(float x, float y)
    {
        grid_.move(this, x, y);
    }

    private float speed_ = 2f;
    private Grid_soli grid_;
    public float x_, y_;

    public Unit_soli prev_;
    public Unit_soli next_;
}
