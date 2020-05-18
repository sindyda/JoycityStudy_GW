using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager_Soli : MonoBehaviour
{
    void Start()
    {
        soli_ = new GameObject_Soli(new InputComponent_Soli(), new PhysicsComponent_Soli(), new GraphicsComponent_Soli());
        world_ = new World_Soli();
        graphics_ = new Graphics_Soli();
    }

    void Update()
    {
        soli_.Update(world_, graphics_);
    }

    GameObject_Soli soli_ = null;
    World_Soli world_ = null;
    Graphics_Soli graphics_ = null;
}
