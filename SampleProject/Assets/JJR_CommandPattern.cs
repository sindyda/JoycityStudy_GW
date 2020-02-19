using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Command
{
    public GameObject commandObject = null;
    public virtual void Execute(GameObject obj)
    {
        commandObject = obj;
    }
    public virtual void Undo() { }
    public virtual void Redo() { }
}

public class MoveCommand : Command
{
    Vector3 addPosition;
    Vector3 befPosition;

    public MoveCommand(Vector3 addPosition)
    {
        this.addPosition = addPosition;
    }

    public override void Execute(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }

        base.Execute(obj);

        befPosition = obj.transform.position;

        obj.transform.position += addPosition;
    }

    public override void Undo()
    {
        if (commandObject == null)
        {
            return;
        }

        base.Undo();
        commandObject.transform.position = befPosition;
    }

    public override void Redo()
    {
        if (commandObject == null)
        {
            return;
        }

        base.Undo();
        commandObject.transform.position += addPosition;
    }
}

public class ScaleCommand : Command
{
    Vector3 addScale;
    Vector3 befScale;

    public ScaleCommand(Vector3 addScale)
    {
        this.addScale = addScale;
    }

    public override void Execute(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }

        base.Execute(obj);

        befScale = obj.transform.localScale;

        obj.transform.localScale += addScale;
    }

    public override void Undo()
    {
        if (commandObject == null)
        {
            return;
        }

        base.Undo();
        commandObject.transform.localScale = befScale;
    }

    public override void Redo()
    {
        if (commandObject == null)
        {
            return;
        }

        base.Undo();
        commandObject.transform.localScale += addScale;
    }
}

public class JJR_CommandPattern : MonoBehaviour
{
    int cursorIndex = -1;
    List<Command> commands = new List<Command>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var command = handleInput();
            if (command != null)
            {
                int cursorNextIndex = cursorIndex + 1;
                if (cursorNextIndex < commands.Count)
                {
                    commands.RemoveRange(cursorNextIndex, commands.Count - cursorNextIndex);
                }

                command.Execute(gameObject);
                commands.Add(command);
                MoveCursorIndex(1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (cursorIndex >= 0 && cursorIndex < commands.Count)
            {
                var command = commands[cursorIndex];
                if (command != null)
                {
                    int befCursorIndex = cursorIndex;
                    MoveCursorIndex(-1);

                    if (befCursorIndex != cursorIndex)
                    {
                        command.Undo();
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (cursorIndex >= 0 && cursorIndex < commands.Count)
            {
                var command = commands[cursorIndex];
                {
                    int befCursorIndex = cursorIndex;
                    MoveCursorIndex(1);

                    if (befCursorIndex != cursorIndex)
                    {
                        command.Redo();
                    }
                }
            }
        }
    }

    void MoveCursorIndex(int move)
    {
        cursorIndex += move;

        if(cursorIndex <= 0)
        {
            cursorIndex = 0;
        }
        else if(cursorIndex >= commands.Count)
        {
            cursorIndex = commands.Count - 1;
        }
    }

    Command handleInput()
    {
        int random = UnityEngine.Random.Range(0, 2);
        if (random == 0)
        {
            return new MoveCommand(new Vector3(0, 1, 0));
        }
        else if (random == 1)
        {
            return new ScaleCommand(new Vector3(0.1f, 0.1f, 0.1f));
        }

        return null;
    }
}


