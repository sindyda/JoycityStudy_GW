 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_Hero : MonoBehaviour
{
    JJR_State state = null;
    // Start is called before the first frame update
    void Start()
    {
        state = new JJR_Idle();
        state.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        JJR_State nextState = null;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextState = state.Input(KeyCode.Space);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            nextState = state.Input(KeyCode.UpArrow);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            nextState = state.Input(KeyCode.DownArrow);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            nextState = state.Input(KeyCode.LeftArrow);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            nextState = state.Input(KeyCode.RightArrow);
        }

        if(nextState != null)
        {
            nextState.Enter();
            state = nextState;
        }
    }
}
