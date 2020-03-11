using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Charactor : MonoBehaviour
{
    KMS_StatePattern charactorState = null;

    private void Start()
    {
        charactorState = new KMS_State_Stand();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpdateState(InputState.INPUT_PRESS_DOWN);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            UpdateState(InputState.INPUT_RELEASE_DOWN);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            UpdateState(InputState.INPUT_PRESS_UP);
        }

        if (charactorState != null)
        {
            var changeState = charactorState.Update(gameObject);
            if (changeState != null)
            {
                charactorState = changeState;
                charactorState.Enter(gameObject);
            }
        }
    }

    void UpdateState(InputState input)
    {
        var state = charactorState.InputHandler(this, input);
        if (state != null)
        {
            charactorState = state;
            charactorState.Enter(gameObject);
        }
    }
}
