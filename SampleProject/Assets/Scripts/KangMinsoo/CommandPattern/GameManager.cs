using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Unit unit = null;
    List<CommandPattern> commandList = new List<CommandPattern>();
    int currentMoveIndex = 0;

    public void InputKey(CommandPattern pattern)
    {
        // 새로 스택을 쌓아야 한다면
        if (currentMoveIndex + 1 < commandList.Count)
        {
            commandList.RemoveRange(currentMoveIndex, commandList.Count - currentMoveIndex);
        }

        commandList.Add(pattern);
        commandList[currentMoveIndex].ExecuteAction();
        ++currentMoveIndex;
    }

    void Update()
    {
        if (unit != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                InputKey(new MoveUnitCommand(unit, unit.posX - 1, unit.posY));
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                InputKey(new MoveUnitCommand(unit, unit.posX, unit.posY + 1));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                InputKey(new MoveUnitCommand(unit, unit.posX + 1, unit.posY));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                InputKey(new MoveUnitCommand(unit, unit.posX, unit.posY - 1));
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                InputKey(new ScaleUnitCommand(unit, unit.scaleX + 1.0f, unit.scaleY + 1.0f));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                InputKey(new ScaleUnitCommand(unit, unit.scaleX - 1.0f, unit.scaleY - 1.0f));
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                if (currentMoveIndex > 0)
                {
                    var moveUnit = commandList[--currentMoveIndex] as CommandPattern;
                    moveUnit.undoAction();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentMoveIndex < commandList.Count)
                {
                    var moveUnit = commandList[currentMoveIndex++] as CommandPattern;
                    moveUnit.redoAction();
                }
            }
        }
    }
}
