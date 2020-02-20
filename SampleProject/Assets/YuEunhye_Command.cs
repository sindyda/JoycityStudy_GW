using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YuEunhye_Command : MonoBehaviour
{
    /*** 1번째 예제
    #region Command
    public class Command
    {
        public virtual void Execute(Unit unit) { }
    }

    public class JumpCommand : Command
    {
        public override void Execute(Unit unit)
        {
            unit.Jump();
        }
    }
    public class FireGunCommand : Command
    {
        public override void Execute(Unit unit)
        {
            unit.FireGun();
        }
    }
    public class SwapWeaponCommand : Command
    {
        public override void Execute(Unit unit)
        {
            unit.SwapWeapon();
        }
    }
    public class LurchInEffectivelyCommand : Command
    {
        public override void Execute(Unit unit)
        {
            unit.LurchInEffectively();
        }
    }
    #endregion Command

    #region Handler
    public class InputHandler
    {
        private Command ButtonX = new JumpCommand();
        private Command ButtonY = new FireGunCommand();
        private Command ButtonA = new SwapWeaponCommand();
        private Command ButtonB = new LurchInEffectivelyCommand();

        public Command handlerInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                return ButtonX;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                return ButtonY;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                return ButtonA;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                return ButtonB;
            }

            return null;
        }
    }
    #endregion Handler

    #region Unit
    public class Unit
    {
        public string _commandText = "";
        public void Jump()
        {
            _commandText = "Jump";
        }
        public void FireGun()
        {
            _commandText = "Fire Gun";
        }
        public void SwapWeapon()
        {
            _commandText = "Swap Weapon";
        }
        public void LurchInEffectively()
        {
            _commandText = "Lurch In Effectively";
        }
    }
    #endregion Unit
    1번째 예제 ***/

    #region Command
    public class Command
    {
        public virtual void Execute() { }
        public virtual void Undo() { }
        public virtual void Redo() { }
    }

    public class MoveUnitCommand : Command
    {
        private Unit _unit = null;
        private int _x = 0;
        private int _y = 0;
        private int _xBefore = 0;
        private int _yBefore = 0;

        public MoveUnitCommand() { }
        public MoveUnitCommand(Unit unit, int x, int y)
        {
            _unit = unit;
            _x = x;
            _y = y;
        }
        public override void Execute()
        {
            if (_unit == null)
                return;

            _xBefore = _unit._x;
            _yBefore = _unit._y;

            _unit.MoveTo(_x,_y);
        }
        public override void Undo()
        {
            if (_unit == null)
                return;

            _unit.MoveTo(_xBefore, _yBefore);
        }
        public override void Redo()
        {
            if (_unit == null)
                return;

            _unit.MoveTo(_x, _y);
        }
    }
    #endregion Command

    #region Handler
    public class InputHandler
    {
        public Command handlerInput(Unit unit)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                return new MoveUnitCommand(unit, unit._x, unit._y + 1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                return new MoveUnitCommand(unit, unit._x, unit._y - 1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                return new MoveUnitCommand(unit, unit._x + 1, unit._y);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                return new MoveUnitCommand(unit, unit._x - 1, unit._y);
            }

            return null;
        }
    }
    #endregion Handler

    #region Unit
    public class Unit
    {
        public int _x = 0;
        public int _y = 0;
        public string _commandText = "";
        public void MoveTo(int x, int y)
        {
            _x = x;
            _y = y;
            _commandText = string.Format("x:{0}, y:{1}", _x, _y);
        }
    }
    #endregion Unit

    public Text _text;

    private InputHandler _handler = new InputHandler();
    private Unit _unit = new Unit();

    private List<Command> _list = new List<Command>();

    private const int INVALID_INDEX = -1;
    private const int START_INDEX = 0;
    private int selectIndex = INVALID_INDEX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int maxIndex = _list.Count - 1;

        var command = _handler.handlerInput(_unit);
        if (command != null)
        {
            if (selectIndex < maxIndex)
            {
                _list.RemoveRange(selectIndex + 1, maxIndex - selectIndex);
            }

            command.Execute();
            _list.Add(command);

            selectIndex = _list.Count - 1;
            Debug.Log(string.Format("Execute[{0}]" + _unit._commandText, selectIndex));
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (maxIndex >= 0)
            {
                if (selectIndex == START_INDEX)
                {
                    // 더 이상 뒤로 갈 수 없다.
                }
                else
                {
                    _list[selectIndex].Undo();
                    --selectIndex;
                    Debug.Log(string.Format("Undo[{0}]" + _unit._commandText, selectIndex));
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (selectIndex == INVALID_INDEX)
            {
                // 더 이상 앞으로 나갈 수 없다.
            }
            else if (selectIndex >= maxIndex)
            {
                // 더 이상 앞으로 나갈 수 없다.
            }
            else
            {
                ++selectIndex;
                _list[selectIndex].Redo();
                Debug.Log(string.Format("Redo[{0}]" + _unit._commandText, selectIndex));
            }
        }

        _text.text = _unit._commandText;
    }
}
