using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliUnit : MonoBehaviour
{
    private SoliCommand buttonUp = new UpSoliCommand();
    private SoliCommand buttonDown = new DownSoliCommand();
    private SoliCommand buttonRight = new RightSoliCommand();
    private SoliCommand buttonLeft = new LeftSoliCommand();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            buttonUp.excute(this);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            buttonDown.excute(this);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            buttonRight.excute(this);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            buttonLeft.excute(this);
        }
    }
}
