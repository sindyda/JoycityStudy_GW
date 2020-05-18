using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_Main : MonoBehaviour
{
    public JJR_Object Object = null;
    public List<JJR_ActionComponent> actionComponentList = new List<JJR_ActionComponent>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SendAddSpeed(2);

        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
            SendAddSpeed(-2);
        }
    }

    void SendAddSpeed(float addSpeed)
    {
        for (int i = 0; i < actionComponentList.Count; ++i)
        {
            var actionComponent = actionComponentList[i];

            if (actionComponent != null)
            {
                actionComponent.SendAddSpeed(addSpeed);
            }
        }
    }
}
