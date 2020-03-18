using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBuffer
{
    public const int WIDTH = 10;
    public const int HEIGHT = 10;

    char[][] pixels = new char[HEIGHT][];

    public FrameBuffer() { Clear(); }
    public void Clear()
    {
        for (int i = 0; i < HEIGHT; ++i)
        {
            pixels[i] = new char[WIDTH + 1];
            for (int j = 0; j < WIDTH + 1; ++j)
            {
                if(j == WIDTH)
                {
                    pixels[i][j] = '\n';
                }
                else
                {
                    pixels[i][j] = 'x';
                }
                
            }
        }
    }

    public void Draw(int x, int y)
    {
        if(x >= WIDTH || y >= HEIGHT)
        {
            return;
        }
        pixels[y][x] = 'O';
    }

    public string GetBuffers()
    {
        string ret = "";
        for(int i = 0; i < HEIGHT; ++i)
        {
            ret += new string(pixels[i]);
        }
        return ret;
    }
}

public class Scene
{
    public Scene()
    {
        frameBuffer[0] = new FrameBuffer();
        frameBuffer[1] = new FrameBuffer();
        current = frameBuffer[0];
        next = frameBuffer[1];
    }

    public void draw()
    {
        current.Clear();
        current.Draw(posX, posY);

        posX++;
        if (posX == FrameBuffer.WIDTH)
        {
            posX = 0;
            posY++;
        }
        if (posY == FrameBuffer.HEIGHT)
        {
            posY = 0;
        }

        Debug.Log("\n" + current.GetBuffers());

        swap();
    }

    void swap()
    {
        FrameBuffer temp = current;
        current = next;
        next = temp;
    }

    FrameBuffer[] frameBuffer = new FrameBuffer[2];
    FrameBuffer current = null;
    FrameBuffer next = null;

    int posX = 0;
    int posY = 0;
}

public class JJR_Main : MonoBehaviour
{

    Scene scene = new Scene();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scene.draw();
        }
    }
}
