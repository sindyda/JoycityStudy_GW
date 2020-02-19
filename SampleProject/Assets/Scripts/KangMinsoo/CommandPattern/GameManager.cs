using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Unit unit = null;
    List<CommandPattern> commandList = new List<CommandPattern>();
    int currentMoveIndex = 0;
    int maxMoveIndex = 0;


    // Update is called once per frame
    void Update()
    {
        if (unit != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                commandList.Add(new MoveUnitCommand(unit, unit.posX - 1, unit.posY));
                commandList[currentMoveIndex].executeAction();
                ++currentMoveIndex;
                maxMoveIndex = commandList.Count;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                commandList.Add(new MoveUnitCommand(unit, unit.posX, unit.posY + 1));
                commandList[currentMoveIndex].executeAction();
                ++currentMoveIndex;
                maxMoveIndex = commandList.Count;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                commandList.Add(new MoveUnitCommand(unit, unit.posX + 1, unit.posY));
                commandList[currentMoveIndex].executeAction();
                ++currentMoveIndex;
                maxMoveIndex = commandList.Count;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                commandList.Add(new MoveUnitCommand(unit, unit.posX, unit.posY - 1));
                commandList[currentMoveIndex].executeAction();
                ++currentMoveIndex;
                maxMoveIndex = commandList.Count;
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log(currentMoveIndex);
                if (currentMoveIndex > 0)
                {
                    var moveUnit = commandList[--currentMoveIndex] as MoveUnitCommand;
                    unit.MoveTo(moveUnit.undoX, moveUnit.undoY);
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(currentMoveIndex);
                if (currentMoveIndex < commandList.Count)
                {
                    var moveUnit = commandList[currentMoveIndex++] as MoveUnitCommand;
                    unit.MoveTo(moveUnit.undoX, moveUnit.undoY);
                }
            }
        }
    }
}
