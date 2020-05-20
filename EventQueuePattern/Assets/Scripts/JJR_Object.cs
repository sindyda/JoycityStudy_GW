using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InputKey(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.UpArrow:
                transform.localPosition += new Vector3(0, 0.3f, 0);
                break;
            case KeyCode.DownArrow:
                transform.localPosition += new Vector3(0, -0.3f, 0);
                break;
            case KeyCode.LeftArrow:
                transform.localPosition += new Vector3(-0.3f, 0, 0);
                break;
            case KeyCode.RightArrow:
                transform.localPosition += new Vector3(0.3f, 0, 0);
                break;
        }
    }
}
