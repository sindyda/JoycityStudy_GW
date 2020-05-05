using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JJR_Parser
{
    string result = "";
    public void Parse(string script)
    {
        string[] buildings = script.Split('\n');

        for (int i = 0; i < buildings.Length; ++i)
        {
            string[] datas = buildings[i].Split(':');

            if (datas.Length != 2)
            {
                Debug.LogError("Data Error.");
                continue;
            }

            string command = datas[0];
            string data = datas[1];

            Action<byte, string> AddInstruction = (inst, instData) =>
            {
                result += inst;
                result += ":";
                result += instData;
                result += "/";
            };

            switch (command)
            {
                case "InitUnit":
                    AddInstruction((byte)Instruction.INST_INIT_UNIT, data);
                    break;
                case "SetName":
                    AddInstruction((byte)Instruction.INST_SET_NAME, data);
                    break;
                case "SetHp":
                    AddInstruction((byte)Instruction.INST_SET_HP, data);
                    break;
                case "SetPower":
                    AddInstruction((byte)Instruction.INST_SET_POWER, data);
                    break;
                case "Attack":
                    AddInstruction((byte)Instruction.INST_ATTACK, data);
                    break;
                default:
                    break;
            }
        }

    }

    public string GetResult()
    {
        return result;
    }
}
