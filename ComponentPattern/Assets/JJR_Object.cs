using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_Object : MonoBehaviour
{
    public JJR_ActionComponent actionComponent = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (actionComponent != null)
        {
            actionComponent.UpdateAction(this);
        }
    }
}
