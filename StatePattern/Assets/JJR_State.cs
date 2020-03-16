using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JJR_Command
{
    Dictionary<SKILL, SKILL_COMMAND> commandList = new Dictionary<SKILL, SKILL_COMMAND>();
    List<SKILL_COMMAND> checkCommands = null;
    List<KeyCode> inputCommand = new List<KeyCode>();

    public void Add(SKILL_COMMAND command)
    {
        if (command == null)
        {
            return;
        }

        if (commandList.ContainsKey(command.kind))
        {
            commandList[command.kind] = command;
        }
        else
        {
            commandList.Add(command.kind, command);
        }

        InitCommand();
    }

    public SKILL InputCommand(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.DownArrow:
            case KeyCode.UpArrow:
            case KeyCode.LeftArrow:
            case KeyCode.RightArrow:
                inputCommand.Add(key);
                SKILL outSkill;
                if (CheckCommand(out outSkill) == false)
                {
                    InitCommand();
                    inputCommand.Add(key);
                    break;
                }

                if (outSkill != SKILL.NONE)
                {
                    InitCommand();
                    return outSkill;
                }
                break;
            default:
                InitCommand();
                break;
        }

        return SKILL.NONE;
    }

    public void Update()
    {
        // 커맨드 입력시간이 지났다면 InitCommand(); 호출
    }

    public void InitCommand()
    {
        checkCommands = commandList.Values.ToList();
        inputCommand.Clear();
    }

    public bool CheckCommand(out SKILL outSkill)
    {
        outSkill = SKILL.NONE;

        for (int i = 0; i < checkCommands.Count;)
        {
            bool isRemove = false;
            for (int j = 0; j < inputCommand.Count; ++j)
            {
                if (inputCommand[j] != checkCommands[i].command[j])
                {
                    isRemove = true;
                    break;
                }
            }

            if (isRemove)
            {
                checkCommands.RemoveAt(i);
            }
            else
            {
                if (checkCommands[i].command.Count() == inputCommand.Count())
                {
                    outSkill = checkCommands[i].kind;
                    return true;
                }
                ++i;
            }
        }

        if (checkCommands.Count > 0)
        {
            return true;
        }
        return false;
    }
}

public enum SKILL
{
    NONE,
    ATTACK,
    AVOID,
}

public class SKILL_COMMAND
{
    public SKILL kind;
    public KeyCode[] command;
    public SKILL_COMMAND(SKILL kind, KeyCode[] command)
    {
        this.kind = kind;
        this.command = command;
    }
};
public class JJR_State
{
    JJR_Command commandManager = new JJR_Command();

    public virtual void Enter()
    {
    }
    public virtual void Update()
    {

    }

    public virtual JJR_State Input(KeyCode key)
    {
        var skill = commandManager.InputCommand(key);
        if (skill != SKILL.NONE)
        {
            UseSkill(skill);
        }

        return null;
    }

    public virtual void UseSkill(SKILL kind)
    {

    }

    public void AddCommand(SKILL_COMMAND command)
    {
        commandManager.Add(command);
    }
}

public class JJR_Idle : JJR_State
{
    public override void Enter()
    {
        Debug.Log("Current State : JJR_Idle");

        AddCommand(new SKILL_COMMAND(SKILL.ATTACK, new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow }));
        AddCommand(new SKILL_COMMAND(SKILL.AVOID, new KeyCode[] { KeyCode.LeftArrow, KeyCode.LeftArrow, KeyCode.LeftArrow }));
    }

    public override void Update()
    {

    }

    public override JJR_State Input(KeyCode key)
    {
        base.Input(key);

        if (key == KeyCode.Space)
        {
            return new JJR_Fly();
        }

        return null;
    }

    public override void UseSkill(SKILL kind)
    {
        Debug.Log(string.Format("JJR_Idle - Use : {0}", kind.ToString()));
    }
}

public class JJR_Fly : JJR_State
{
    public override void Enter()
    {
        Debug.Log("Current State : JJR_Fly");
        AddCommand(new SKILL_COMMAND(SKILL.ATTACK, new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow }));
        AddCommand(new SKILL_COMMAND(SKILL.AVOID, new KeyCode[] { KeyCode.LeftArrow, KeyCode.LeftArrow, KeyCode.LeftArrow }));
    }

    public override void Update()
    {

    }

    public override JJR_State Input(KeyCode key)
    {
        base.Input(key);

        if (key == KeyCode.Space)
        {
            return new JJR_Idle();
        }

        return null;
    }

    public override void UseSkill(SKILL kind)
    {
        Debug.Log(string.Format("JJR_Fly - Use : {0}", kind.ToString()));
    }
}

