using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_EventQueueManager
{
    private int headIndex = 0;
    private int tailIndex = 0;

    public void PushEvent(KeyCode KeyCode)
    {
        int inputNextIndex = (tailIndex + 1) % PENDING_MAX_LENGTH;
        if (inputNextIndex == headIndex)
        {
            return;
        }

        pending[tailIndex] = KeyCode;

        tailIndex = inputNextIndex;
    }

    public KeyCode PopEvent()
    {
        KeyCode returnValue = KeyCode.None;
        if (headIndex == tailIndex)
        {
            return returnValue;
        }

        returnValue = pending[headIndex];
        headIndex = (headIndex + 1) % PENDING_MAX_LENGTH;

        return returnValue;
    }

    const int PENDING_MAX_LENGTH = 16;
    KeyCode[] pending = new KeyCode[PENDING_MAX_LENGTH];
};
public class JJR_Main : MonoBehaviour
{
    JJR_EventQueueManager eventQueueManager = new JJR_EventQueueManager();
    public JJR_Object obj = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            eventQueueManager.PushEvent(KeyCode.UpArrow);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            eventQueueManager.PushEvent(KeyCode.DownArrow);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            eventQueueManager.PushEvent(KeyCode.LeftArrow);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            eventQueueManager.PushEvent(KeyCode.RightArrow);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (obj != null)
            {
                obj.InputKey(eventQueueManager.PopEvent());
            }
        }
    }
}
