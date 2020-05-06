using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UNE_Main : MonoBehaviour
{
    enum eINSTRUCTION
    {
        INST_SET_HEALTH = 0x00,
        INST_SET_WISDOM = 0x01,
        INST_SET_AGILITY = 0x02,

        INST_GET_HEALTH = 0x06,
        INST_GET_WISDOM = 0x07,
        INST_GET_AGILITY = 0x08,

        INST_ADD = 0x09,
        INST_MINUS = 0x10,
        INST_MULTIPLE = 0x11,
        INST_DIVIDE = 0x12,

        INST_INPUT = 0x13,
        INST_PRINT = 0x14,
    }
    public class Wiard
    {
        public int _health = 0;
        public int _wisdom = 0;
        public int _agility = 0;

        public Wiard(int h, int w, int a)
        {
            _health = h;
            _wisdom = w;
            _agility = a;
        }
    }

    public class VM
    {
        const int _MAX_STACK = 128;
        int _stackSize = 0;
        int[] _stack = new int[_MAX_STACK];
        Dictionary<int, Wiard> _wizards = new Dictionary<int, Wiard>();

        public VM(int index, int health, int wisdom, int agility)
        {
            _wizards.Add(index, new Wiard(health, wisdom, agility));
        }

        void Push(int value)
        {
            Assert(_stackSize < _MAX_STACK);
            _stack[_stackSize++] = value;
        }
        int Pop()
        {
            Assert(_stackSize > 0);
            return _stack[--_stackSize];
        }
        public void Interpret(List<byte> bytecodes)
        {
            int size = bytecodes.Count;
            for (int i = 0; i < size; ++i)
            {
                var bytecode = bytecodes[i];
                switch (bytecode)
                {
                    case (byte)eINSTRUCTION.INST_SET_HEALTH:
                        {
                            int value = Pop();
                            int wizard = Pop();
                            SetHealth(wizard, value);
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_SET_WISDOM:
                        {
                            int value = Pop();
                            int wizard = Pop();
                            SetWisdom(wizard, value);
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_SET_AGILITY:
                        {
                            int value = Pop();
                            int wizard = Pop();
                            SetAgility(wizard, value);
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_GET_HEALTH:
                        {
                            int wizard = Pop();
                            Push(GetHealth(wizard));
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_GET_WISDOM:
                        {
                            int wizard = Pop();
                            Push(GetWisdom(wizard));
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_GET_AGILITY:
                        {
                            int wizard = Pop();
                            Push(GetAgility(wizard));
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_ADD:
                        {
                            int b = Pop();
                            int a = Pop();
                            Push(a + b);
                            Debug.LogFormat("num1({0}) <color=yellow>+</color> num2({1}) = <color=yellow>{2}</color> ", a, b, a + b);
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_MINUS:
                        {
                            int b = Pop();
                            int a = Pop();
                            Push(a - b);
                            Debug.LogFormat("num1({0}) <color=yellow>-</color> num2({1}) = <color=yellow>{2}</color> ", a, b, a - b);
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_MULTIPLE:
                        {
                            int b = Pop();
                            int a = Pop();
                            Push(a * b);
                            Debug.LogFormat("num1({0}) <color=yellow>*</color> num2({1}) = <color=yellow>{2}</color> ", a, b, a * b);
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_DIVIDE:
                        {
                            int b = Pop();
                            int a = Pop();
                            Push(a / b);
                            Debug.LogFormat("num1({0}) <color=yellow>/</color> num2({1}) = <color=yellow>{2}</color> ", a, b, a/b);
                            break;
                        }

                    case (byte)eINSTRUCTION.INST_INPUT:
                        {
                            int value = bytecodes[++i];
                            InputValue(value);
                            break;
                        }
                    case (byte)eINSTRUCTION.INST_PRINT:
                        {
                            int wizard = Pop();
                            Print(wizard);
                            break;
                        }
                }
            }
        }
        void Assert(bool flag)
        {
            System.Diagnostics.Debug.Assert(flag);
        }
        void SetHealth(int wizard, int value)
        {
            Assert(_wizards.ContainsKey(wizard));
            _wizards[wizard]._health = value;
            Debug.LogFormat("SetHealth wizard({0}), value({1})", wizard, value);
        }
        void SetWisdom(int wizard, int value)
        {
            Assert(_wizards.ContainsKey(wizard));
            _wizards[wizard]._wisdom = value;
            Debug.LogFormat("SetWisdom wizard({0}), value({1})", wizard, value);
        }
        void SetAgility(int wizard, int value)
        {
            Assert(_wizards.ContainsKey(wizard));
            _wizards[wizard]._agility = value;
            Debug.LogFormat("SetAgility wizard({0}), value({1})", wizard, value);
        }
        int GetHealth(int wizard)
        {
            Assert(_wizards.ContainsKey(wizard));
            Debug.LogFormat("GetHealth wizard({0}), value({1})", wizard, _wizards[wizard]._health);
            return _wizards[wizard]._health;
        }
        int GetWisdom(int wizard)
        {
            Assert(_wizards.ContainsKey(wizard));
            Debug.LogFormat("GetWisdom wizard({0}), value({1})", wizard, _wizards[wizard]._wisdom);
            return _wizards[wizard]._wisdom;
        }
        int GetAgility(int wizard)
        {
            Assert(_wizards.ContainsKey(wizard));
            Debug.LogFormat("GetAgility wizard({0}), value({1})", wizard, _wizards[wizard]._agility);
            return _wizards[wizard]._agility;
        }

        void InputValue(int value)
        {
            Push(value);
            //Debug.LogFormat("Input number({0})", value);
        }
        void Print(int wizard)
        {
            Assert(_wizards.ContainsKey(wizard));
            Debug.LogFormat("<color=cyan>--> Wizard({0})</color> Health({1}) Wisdom({2}) Agility({3})", wizard, _wizards[wizard]._health, _wizards[wizard]._wisdom, _wizards[wizard]._agility);
        }
    }

    List<byte> insts = new List<byte>();
    public Text viewText;

    // Start is called before the first frame update
    void Start()
    {
        //List<byte> bHealth = new List<byte> {
        //    (byte)eINSTRUCTION.INST_INPUT, 0,
        //    (byte)eINSTRUCTION.INST_INPUT, 0,
        //    (byte)eINSTRUCTION.INST_GET_HEALTH,
        //    (byte)eINSTRUCTION.INST_INPUT, 0,
        //    (byte)eINSTRUCTION.INST_GET_AGILITY,
        //    (byte)eINSTRUCTION.INST_INPUT, 0,
        //    (byte)eINSTRUCTION.INST_GET_WISDOM,
        //    (byte)eINSTRUCTION.INST_ADD,
        //    (byte)eINSTRUCTION.INST_INPUT, 2,
        //    (byte)eINSTRUCTION.INST_DIVIDE,
        //    (byte)eINSTRUCTION.INST_ADD,
        //    (byte)eINSTRUCTION.INST_SET_HEALTH,
        //
        //    (byte)eINSTRUCTION.INST_INPUT, 0,
        //    (byte)eINSTRUCTION.INST_PRINT,
        //};

        //VM vm = new VM(0, 45, 7, 11);
        //vm.Interpret(bHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick_Clear()
    {
        insts.Clear();
        viewText.text = "";
    }
    public void OnClick_GetHealth()
    {
        insts.Add((byte)eINSTRUCTION.INST_INPUT);
        insts.Add(0);
        insts.Add((byte)eINSTRUCTION.INST_GET_HEALTH);
        viewText.text += "GET_HEALTH ";
    }
    public void OnClick_GetWisdom()
    {
        insts.Add((byte)eINSTRUCTION.INST_INPUT);
        insts.Add(0);
        insts.Add((byte)eINSTRUCTION.INST_GET_WISDOM);
        viewText.text += "GET_WISDOM ";
    }
    public void OnClick_GetAgility()
    {
        insts.Add((byte)eINSTRUCTION.INST_INPUT);
        insts.Add(0);
        insts.Add((byte)eINSTRUCTION.INST_GET_AGILITY);
        viewText.text += "GET_AGILITY ";
    }
    public void OnClick_Add()
    {
        insts.Add((byte)eINSTRUCTION.INST_ADD);
        viewText.text += "+ ";
    }
    public void OnClick_Divide(Text text)
    {
        if (text == null)
            return;

        var inputNum = Convert.ToInt32(text.text);

        insts.Add((byte)eINSTRUCTION.INST_INPUT);
        insts.Add((byte)inputNum);
        insts.Add((byte)eINSTRUCTION.INST_DIVIDE);
        viewText.text += string.Format("/ {0}", inputNum);
    }
    public void OnClick_Start()
    {
        VM vm = new VM(0, 45, 7, 11);
        vm.Interpret(insts);
    }
}
