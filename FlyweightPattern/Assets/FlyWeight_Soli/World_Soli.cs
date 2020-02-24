using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_Soli
{
    public World_Soli()
    {
        grassTerrain_ = new Terrain_Soli(1, false, grassTexture_);
        hillTerrain_ = new Terrain_Soli(1, false, hillTexture_);
        riverTerrain_ = new Terrain_Soli(1, false, riverTexture_);
    }

    const int WIDTH = 20;
    const int HEIGHT = 20;

    public Texture grassTexture_;
    public Texture hillTexture_;
    public Texture riverTexture_;

    private Terrain_Soli[,] tiles_ = new Terrain_Soli[WIDTH, HEIGHT];

    private Terrain_Soli grassTerrain_;
    private Terrain_Soli hillTerrain_;
    private Terrain_Soli riverTerrain_;

    void generateTerrain()
    {
        for (int x = 0; x < WIDTH; ++x)
        {
            for (int y = 0; y < HEIGHT; ++y)
            {
                if(Random.Range(0, WIDTH) == 15)
                    tiles_[x, y] = grassTerrain_;
                else
                    tiles_[x, y] = hillTerrain_;
            }
        }

        int x2 = Random.Range(0, WIDTH);
        for (int y2 = 0; y2 < HEIGHT; ++y2)
        {
            tiles_[x2, y2] = riverTerrain_;
        }
    }
}
