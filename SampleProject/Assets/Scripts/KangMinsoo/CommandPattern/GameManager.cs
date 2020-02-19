using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Unit unit = null;
    List<CommandPattern> commandList = new List<CommandPattern>();
    int currentMoveIndex = 0;


    // Update is called once per frame
    void Update()
    {
        if (unit != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                commandList.Add(new MoveUnitCommand(unit, unit.posX - 1, unit.posY));
                commandList[currentMoveIndex].executeAction(unit.posX - 1, unit.posY);
                ++currentMoveIndex;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                commandList.Add(new MoveUnitCommand(unit, unit.posX, unit.posY + 1));
                commandList[currentMoveIndex].executeAction(unit.posX, unit.posY + 1);
                ++currentMoveIndex;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                commandList.Add(new MoveUnitCommand(unit, unit.posX + 1, unit.posY));
                commandList[currentMoveIndex].executeAction(unit.posX + 1, unit.posY);
                ++currentMoveIndex;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                commandList.Add(new MoveUnitCommand(unit, unit.posX, unit.posY - 1));
                commandList[currentMoveIndex].executeAction(unit.posX, unit.posY - 1);
                ++currentMoveIndex;
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                var moveUnit = commandList[--currentMoveIndex] as MoveUnitCommand;
                unit.MoveTo(moveUnit.undoX, moveUnit.undoY);
            }
        }
    }
}
