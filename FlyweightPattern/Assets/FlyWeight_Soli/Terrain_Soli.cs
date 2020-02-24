using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_Soli
{
    public Terrain_Soli(int movementCost, bool isWater, Texture texture)
    {
        movementCost_ = movementCost;
        isWater_ = isWater;
        texture_ = texture;
    }

    int getmovementCost() { return movementCost_; }
    bool isWater() { return isWater_;}
    Texture GetTexture() { return texture_; }

    private int movementCost_;
    private bool isWater_;
    private Texture texture_;
}
