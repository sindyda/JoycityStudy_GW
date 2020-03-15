using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LeeChangi
{
    public class Transition
    {
        public StateMachine startState { get; private set; }
        public StateMachine targetState { get; private set; }
        public Func<MachineController,bool> Condition { get; private set; }

        public Transition(StateMachine start, StateMachine target, Func<MachineController, bool> cond)
        {
            startState = start;
            targetState = target;
            Condition = cond;
        }
    }


    public class StateMachine 
    {
        public int Index { get; private set; }
        public Action<MachineController> UpdateAction;
        public Action<MachineController> EnterAction;
        public Action<MachineController> LeaveAction;
        public List<Transition> Transitions { get; private set; } = new List<Transition>();

        public StateMachine(int index)
        {
            Index = index;
        }

        public StateMachine CheckCondition(MachineController controller)
        {
            foreach(var trans in Transitions)
            {
                if( trans.Condition?.Invoke(controller) == true)
                {
                    return trans.targetState;
                }
            }
            return null;
        }

    }

    

    public class MachineController
    {
        class MachineComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return string.CompareOrdinal(x, y) == 0;
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }



        Dictionary<int, StateMachine> machines = new Dictionary<int, StateMachine>();

        public Dictionary<string, int> intParams { get; private set; } = new Dictionary<string, int>(new MachineComparer());
        public Dictionary<string, bool> boolParams { get; private set; } = new Dictionary<string, bool>(new MachineComparer());

        StateMachine currentState = null;
        StateMachine startState = new StateMachine(0);

        public MachineController()
        {
            currentState = startState;
        }

        public bool AddState(StateMachine state)
        {
            if(machines.ContainsKey(state.Index))
            {
                return false;
            }

            machines.Add(state.Index, state);
            return true;
        }

        public bool GetState(int index, out StateMachine machine)
        {
            if (machines.TryGetValue(index,out machine))
            {
                return true;
            }

            return false;
        }



        public void Update()
        {
            if(currentState != null)
            {
                
                StateMachine nextState = currentState.CheckCondition(this);
                if (nextState != null)
                {
                    currentState.LeaveAction?.Invoke(this);
                    currentState = nextState;
                    currentState.EnterAction?.Invoke(this);
                }

                currentState.UpdateAction?.Invoke(this);
            }
        }

        public bool SetStartState(int index)
        {
            StateMachine targetstate = null;
            if(machines.TryGetValue(index, out targetstate))
            {
                startState.Transitions.Clear();
                startState.Transitions.Add(new Transition(startState, targetstate, (c) => true));
                return true;
            }
            return false;
        }

        public bool SetBoolParam(string param, bool value)
        {
            if (boolParams.ContainsKey(param))
            {
                boolParams[param] = value;
                return true;
            }
            return false;
        }
    }

    public class LCGStateMachine : MonoBehaviour
    {
        enum EActionState
        {
            Idle = 0,
            Run = 1,
            Attack = 2,
        }

        private bool isInitAnimator = false;
        
        public GameObject gameObj;
        MachineController controller = new MachineController();
        private void Start()
        {
            InitStateMachine();
            isInitAnimator = true;
        }

        private void Update()
        {
            if(isInitAnimator)
            {
                controller.Update();
            }



            if(Input.GetKey(KeyCode.R))
            {
                controller.SetBoolParam("IsRun", true);
            }
            else
            {
                controller.SetBoolParam("IsRun", false);
            }

            if(Input.GetKey(KeyCode.A))
            {
                controller.SetBoolParam("IsAttack", true);
            }
        }

        
        
        private void InitStateMachine()
        {
            controller.AddState(StateCreateTest.CreateIdleAction((int)EActionState.Idle));
            controller.AddState(StateCreateTest.CreateRunAction((int)EActionState.Run));
            controller.AddState(StateCreateTest.CreateAttackAction((int)EActionState.Attack));

            controller.boolParams.Add("IsRun", false);
            controller.boolParams.Add("IsAttack", false);

            {
                StateMachine idlemachine = null;
                if (controller.GetState((int)EActionState.Idle, out idlemachine))
                {
                    StateMachine runmachine = null;
                    if (controller.GetState((int)EActionState.Run, out runmachine))
                    {
                        idlemachine.Transitions.Add(new Transition(idlemachine, runmachine, (c) =>
                        {
                            bool isRun = false;
                            if (c.boolParams.TryGetValue("IsRun", out isRun))
                            {
                                return isRun;
                            }
                            return false;
                        }));
                    }
                }
            }

            {
                StateMachine startmachine = null;
                if (controller.GetState((int)EActionState.Run, out startmachine))
                {
                    StateMachine targetmachine = null;
                    if (controller.GetState((int)EActionState.Idle, out targetmachine))
                    {
                        startmachine.Transitions.Add(new Transition(startmachine, targetmachine, (c) =>
                        {
                            bool isRun = false;
                            if (c.boolParams.TryGetValue("IsRun", out isRun))
                            {
                                return !isRun;
                            }
                            return false;
                        }));
                    }
                }
            }

            {
                StateMachine startmachine = null;
                if (controller.GetState((int)EActionState.Idle, out startmachine))
                {
                    StateMachine targetmachine = null;
                    if (controller.GetState((int)EActionState.Attack, out targetmachine))
                    {
                        startmachine.Transitions.Add(new Transition(startmachine, targetmachine, (c) =>
                        {
                            bool isvalue = false;
                            if (c.boolParams.TryGetValue("IsAttack", out isvalue))
                            {
                                return isvalue;
                            }
                            return false;
                        }));
                    }
                }
            }

            {
                StateMachine startmachine = null;
                if (controller.GetState((int)EActionState.Run, out startmachine))
                {
                    StateMachine targetmachine = null;
                    if (controller.GetState((int)EActionState.Attack, out targetmachine))
                    {
                        startmachine.Transitions.Add(new Transition(startmachine, targetmachine, (c) =>
                        {
                            bool isvalue = false;
                            if (c.boolParams.TryGetValue("IsAttack", out isvalue))
                            {
                                return isvalue;
                            }
                            return false;
                        }));
                    }
                }
            }

            {
                StateMachine startmachine = null;
                if (controller.GetState((int)EActionState.Attack, out startmachine))
                {
                    StateMachine targetmachine = null;
                    if (controller.GetState((int)EActionState.Run, out targetmachine))
                    {
                        startmachine.Transitions.Add(new Transition(startmachine, targetmachine, (c) =>
                        {
                            bool isattack = false;
                            if (c.boolParams.TryGetValue("IsAttack", out isattack))
                            {
                                if(!isattack)
                                {
                                    bool isRun = false;
                                    if (c.boolParams.TryGetValue("IsRun", out isRun))
                                    {
                                        return isRun;
                                    }
                                }
                            }
                            return false;
                        }));
                    }
                }
            }

            {
                StateMachine startmachine = null;
                if (controller.GetState((int)EActionState.Attack, out startmachine))
                {
                    StateMachine targetmachine = null;
                    if (controller.GetState((int)EActionState.Idle, out targetmachine))
                    {
                        startmachine.Transitions.Add(new Transition(startmachine, targetmachine, (c) =>
                        {
                            bool isattack = false;
                            if (c.boolParams.TryGetValue("IsAttack", out isattack))
                            {
                                if (!isattack)
                                {
                                    bool isRun = false;
                                    if (c.boolParams.TryGetValue("IsRun", out isRun))
                                    {
                                        return !isRun;
                                    }
                                }
                            }
                            return false;
                        }));
                    }
                }
            }

            controller.SetStartState((int)EActionState.Idle);
        }

        
    }

    public static class StateCreateTest
    {
        public static StateMachine CreateIdleAction(int index)
        {
            StateMachine action = new StateMachine(index);
            action.EnterAction = (c) =>
            {
                //Idle Sprite Set
                Debug.Log("Idle Start!");
            };

            action.UpdateAction = (c) =>
            {
                //Idle Sprite Animation
                Debug.Log("Idle!");
            };

            action.LeaveAction = (c) =>
            {
                //Idle Sprite UnSet
                Debug.Log("Idle End!");
            };
            return action;
        }

        public static StateMachine CreateRunAction(int index)
        {
            StateMachine action = new StateMachine(index);
            action.EnterAction = (c) =>
            {
                //Run Sprite Set
                Debug.Log("Run Start!");
            };

            action.UpdateAction = (c) =>
            {
                //Run Sprite Animation
                Debug.Log("Run!");
            };

            action.LeaveAction = (c) =>
            {
                //Run Sprite UnSet
                Debug.Log("Run End!");
            };
            return action;
        }

        public static StateMachine CreateAttackAction(int index)
        {
            StateMachine action = new StateMachine(index);
            action.EnterAction = (c) =>
            {
                //Run Sprite Set
                Debug.Log("Attack Start!");
            };

            action.UpdateAction = (c) =>
            {
                //Run Sprite Animation
                Debug.Log("Attack!");
                if(c.boolParams.ContainsKey("IsAttack"))
                {
                    c.boolParams["IsAttack"] = false;
                }
            };

            action.LeaveAction = (c) =>
            {
                //Run Sprite UnSet
                Debug.Log("Run End!");
            };
            return action;
        }
    }


}

