using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHAR_STATE
{
    GROUND,
    JUMP
}

public class KMS_ComponentsPattern : MonoBehaviour
{
    public float x, y;
    public CHAR_STATE state = CHAR_STATE.GROUND;

    public void SetComponents(KMS_InputComponent inputcomponent,
        KMS_PhysicsComponent physicscomponent,
        KMS_GraphicsComponent gracphicscomponent)
    {
        inputComponent = inputcomponent;
        physicsComponent = physicscomponent;
        graphicsComponent = gracphicscomponent;
    }

    private KMS_InputComponent inputComponent = null;
    private KMS_PhysicsComponent physicsComponent = null;
    private KMS_GraphicsComponent graphicsComponent = null;

    private void Update()
    {
        if (inputComponent != null)
            inputComponent.Update(this);
        if (physicsComponent != null)
            physicsComponent.Update(this);
        if (graphicsComponent != null)
            graphicsComponent.Update(this);
    }
}
