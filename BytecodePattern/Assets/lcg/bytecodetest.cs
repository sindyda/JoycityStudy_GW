using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;


public class lcgVM
{
    int pivot = 0;
    long[] stack;
    public lcgVM(int size)
    {
        stack = new long[size];
        pivot = 0;
    }

    private void Log()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("[");
        for (int i = 0; i < pivot + 1; i++)
        {
            builder.Append(stack[i]);
            builder.Append(",");
        }
        builder.Append("]");
        Debug.Log(builder.ToString());
    }

    public long Pop()
    {
        var result = stack[--pivot];
        Log();
        return result;
    }

    public void Push(long v)
    {
        stack[pivot++] = v;
        Log();
    }
}

public class lcgInterpret
{
    public enum ByteCommand : long
    {
        LITERAL = 0x01,
        GET_HEALTH = 0x02,
        SET_HEALTH = 0x03,
        GET_ATTACK = 0x04,
        SET_ATTACK = 0x05,
        GET_MAGICPOINT = 0x06,
        SET_MAGICPOINT = 0x07,
        ADD = 0x08,
        DIV = 0x09,
        SUB = 0x0a,

    }

    lcgVM _vm = null;
    List<TestCharacter> chars = null;

    public lcgInterpret(lcgVM vm, List<TestCharacter> characters)
    {
        _vm = vm;
        chars = characters;
    }



    public void Interpret(in long[] bytecode, int size)
    {
        for (int i = 0; i < size; i++)
        {
            ByteCommand code = (ByteCommand)bytecode[i];
            Debug.Log(code.ToString());
            switch (code)
            {
                case ByteCommand.LITERAL:
                    _vm.Push(bytecode[++i]);
                    break;
                case ByteCommand.GET_HEALTH:
                    {
                        long index = _vm.Pop();
                        var character = chars.Find(x => x.Index == index);
                        _vm.Push(character.HP);
                    }
                    break;
                case ByteCommand.SET_HEALTH:
                    {
                        long index = _vm.Pop();
                        long hp = _vm.Pop();
                        var character = chars.Find(x => x.Index == index);
                        character.HP = hp;
                    }
                    break;
                case ByteCommand.GET_ATTACK:
                    {
                        long index = _vm.Pop();
                        var character = chars.Find(x => x.Index == index);
                        _vm.Push(character.Attack);
                    }
                    break;
                case ByteCommand.SET_ATTACK:
                    {
                        long index = _vm.Pop();
                        long attack = _vm.Pop();
                        var character = chars.Find(x => x.Index == index);
                        character.Attack = attack;
                    }
                    break;
                case ByteCommand.GET_MAGICPOINT:
                    {
                        long index = _vm.Pop();
                        var character = chars.Find(x => x.Index == index);
                        _vm.Push(character.MP);
                    }
                    break;
                case ByteCommand.SET_MAGICPOINT:
                    {
                        long index = _vm.Pop();
                        long mp = _vm.Pop();
                        var character = chars.Find(x => x.Index == index);
                        character.MP = mp;
                    }
                    break;
                case ByteCommand.ADD:
                    {
                        long left = _vm.Pop();
                        long right = _vm.Pop();
                        _vm.Push(right + left);
                    }
                    break;
                case ByteCommand.DIV:
                    {
                        long left = _vm.Pop();
                        long right = _vm.Pop();
                        _vm.Push(right / left);
                    }
                    break;
                case ByteCommand.SUB:
                    {
                        long left = _vm.Pop();
                        long right = _vm.Pop();
                        _vm.Push(right - left);
                    }
                    break;
            }
        }
    }

}

public class TestCharacter
{
    public long Index;
    public long HP;
    public long Attack;
    public long MP;
}




public class bytecodetest : MonoBehaviour
{
    List<TestCharacter> characters = new List<TestCharacter>();
    lcgInterpret interpret = null;


    private void Awake()
    {
        MakeCharacters();
        CreateVM();
        CreateTestCode();
    }


    private void MakeCharacters()
    {
        //Make Warrier
        TestCharacter warrier = new TestCharacter();
        warrier.Index = 5;
        warrier.HP = 100;
        warrier.Attack = 10;
        warrier.MP = 0;

        characters.Add(warrier);

        //Make Mage
        TestCharacter mage = new TestCharacter();
        mage.Index = 10;
        mage.HP = 50;
        mage.Attack = 5;
        mage.MP = 50;

        characters.Add(mage);
    }

    private void CreateVM()
    {
        var vm = new lcgVM(1000);
        interpret = new lcgInterpret(vm, characters);

    }

    private void CreateTestCode()
    {
        lcgInterpret.ByteCommand command;
        long[] values = new long[100000];
        values[0] = (long)lcgInterpret.ByteCommand.LITERAL;
        values[1] = 5;
        values[2] = (long)lcgInterpret.ByteCommand.GET_HEALTH;
        values[3] = (long)lcgInterpret.ByteCommand.LITERAL;
        values[4] = 10;
        values[5] = (long)lcgInterpret.ByteCommand.GET_ATTACK;
        values[6] = (long)lcgInterpret.ByteCommand.SUB;
        values[7] = (long)lcgInterpret.ByteCommand.LITERAL;
        values[8] = 5;
        values[9] = (long)lcgInterpret.ByteCommand.SET_HEALTH;

        interpret.Interpret(values, 9);




    }

}


