using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGCommand;
using System;

public class CGMapEditor : MonoBehaviour
{
    
    private List<EditBuildingUnit> buildingList = new List<EditBuildingUnit>();
    private EditBuildingPlayer editorPlayer = null;

    //편집기를 연다.
    public void EditorOpen()
    {
        editorPlayer = new EditBuildingPlayer();
    }

    public void SelectBuilding(EditBuildingUnit unit)
    {
        BuildingSelect select = new BuildingSelect(editorPlayer, unit);
        ExcuteCommand(select);
    }

    public void DeSelectBuilding(EditBuildingUnit unit)
    {
        BuildingDeSelect select = new BuildingDeSelect(editorPlayer, unit);
        ExcuteCommand(select);
    }

    public void MoveBuilding(int x,int y)
    {
        BuildingMove move = new BuildingMove(editorPlayer, x, y);
        ExcuteCommand(move);
    }

    public void RotateBuilding()
    {
        BuildingRotate rot = new BuildingRotate(editorPlayer);
        ExcuteCommand(rot);
    }

    public void Undo()
    {
        UndoCommand();
    }

    public void Redo()
    {
        RedoCommand();
    }


    private List<ICGCommand> commandList = new List<ICGCommand>();
    private int pivot = 0;
    private void ExcuteCommand(ICGCommand command)
    {
        if(pivot < commandList.Count)
        {
            int removecount = commandList.Count - pivot;
            commandList.RemoveRange(pivot, removecount);
        }

        commandList.Add(command);
        command.Excute();
        pivot = commandList.Count;
    }

    private bool UndoCommand()
    {
        if(pivot <= 0)
        {
            //더이상 undo 할게 읎다.
            return false;
        }
        int undoIndex = pivot - 1;
        commandList[undoIndex].Undo();
        pivot = undoIndex;

        return true;
    }

    private bool RedoCommand()
    {
        if(pivot >= commandList.Count)
        {
            //더이상 redo 할게 읎다.
            return false;
        }
        int redoIndex = pivot + 1;
        commandList[redoIndex].Excute();
        pivot = redoIndex;

        return true;
    }

}
