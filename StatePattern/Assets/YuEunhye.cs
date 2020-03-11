using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuEunhye : MonoBehaviour
{
    class User
    {
        UserState _action;
        UserState _equipment;
        virtual public void HandleInput()
        {
            _action.HandleInput(this);
            _equipment.HandleInput(this);
        }
    }

    #region UserState
    class UserState
    {
        virtual public void HandleInput(User obj) { }
        virtual public void Enter(User obj) { }
    }

    #region OnGroundState
    class OnGroundState : UserState
    {
        public override void HandleInput(User user)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //점프
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //엎드리기
            }

            base.HandleInput(user);
        }
        public override void Enter(User obj)
        {
            base.Enter(obj);
        }
    }
    class DuckingState : OnGroundState
    {
        public override void HandleInput(User user)
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                //서기
            }
            base.HandleInput(user);
        }
        public override void Enter(User user)
        {
            base.Enter(user);
        }
    }
    #endregion OnGroundState

    #region EquipmentState
    class EquipmentState : UserState
    {
        public override void HandleInput(User user)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // 1번 무기
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // 2번 무기
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // 3번 무기
            }
            base.HandleInput(user);
        }
        public override void Enter(User user)
        {
            base.Enter(user);
        }
    }
    #endregion EquipmentState

    #endregion UserState

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
