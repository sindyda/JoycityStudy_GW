using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_Soli
{
    public void Update(World_Soli world, Graphics_Soli graphics)
    {
        input_.Update(this);
        physics_.Update(this, world);
        graphics_.Update(this, graphics);
    }

    public int velocity;
    public int x, y;

    private InputComponent_Soli input_;
    private PhysicsComponent_Soli physics_;
    private GraphicsComponent_Soli graphics_;

    public GameObject_Soli(InputComponent_Soli input, PhysicsComponent_Soli physics, GraphicsComponent_Soli graphics)
    {
        input_ = input;
        physics_ = physics;
        graphics_ = graphics;
    }
}

public class InputComponent_Soli
{
    public void Update(GameObject_Soli gameObject)
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.velocity -= WALK_ACCEL;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.velocity += WALK_ACCEL;
        }
    }

    private static int WALK_ACCEL = 1;
}

public class PhysicsComponent_Soli
{
    public void Update(GameObject_Soli gameObject, World_Soli world)
    {
        gameObject.x += gameObject.velocity;
        world.ResolveCollision(gameObject.x, gameObject.y, gameObject.velocity);
    }
}

public class GraphicsComponent_Soli
{
    public void Update(GameObject_Soli gameObject, Graphics_Soli graphics)
    {
        Sprite sprite = spriteStand_;
        if (gameObject.velocity < 0)
            sprite = spriteWalkLeft_;
        else if(gameObject.velocity > 0)
            sprite = spriteWalkRight_;

        graphics.Draw(sprite, gameObject.x, gameObject.y);
    }

    private Sprite spriteStand_;
    private Sprite spriteWalkLeft_;
    private Sprite spriteWalkRight_;
}

public class World_Soli
{
    public void ResolveCollision(int x, int y, int velocity)
    {
        // 충돌?
    }
}

public class Graphics_Soli
{
    public void Draw(Sprite sprite, int x, int y)
    {
        // 화면에 그린다
        Debug.Log("솔이가 " + x + ":" + y + "에 있다");
    }
}
