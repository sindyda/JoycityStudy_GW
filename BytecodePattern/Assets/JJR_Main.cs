using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Instruction
{
    INST_INIT_UNIT = 0x00,
    INST_SET_NAME = 0x01,
    INST_SET_HP = 0x02,
    INST_SET_POWER = 0x03,
    INST_ATTACK = 0x04,
};

public class JJR_Main : MonoBehaviour
{
    JJR_Parser parser = new JJR_Parser();
    JJR_Unit[] units = null;

    const string data = "InitUnit:2\n" +
                        "SetName:0,Dog\n" +
                        "SetHp:0,1000\n" +
                        "SetPower:0,300\n" +

                        "SetName:1,Cat\n" +
                        "SetHp:1,1000\n" +
                        "SetPower:1,500\n" +

                        "Attack:1,0\n" +
                        "Attack:0,1\n" +
                        "Attack:1,0\n" +
                        "Attack:0,1";
    // Start is called before the first frame update
    void Start()
    {
        parser.Parse(data);

        string result = parser.GetResult();

        Debug.Log(string.Format("Parse Result : {0}", result));

        Execute(result);
    }

    void Execute(string script)
    {
        string[] buildings = script.Split('/');

        for (int i = 0; i < buildings.Length; ++i)
        {
            if (string.IsNullOrEmpty(buildings[i]))
            {
                continue;
            }

            string[] datas = buildings[i].Split(':');

            if (datas.Length != 2)
            {
                Debug.LogError("Data Error.");
                continue;
            }

            Instruction inst = (Instruction)byte.Parse(datas[0]);
            string[] instDatas = datas[1].Split(',');

            switch (inst)
            {
                case Instruction.INST_INIT_UNIT:
                    {
                        if (instDatas.Length == 1)
                        {
                            int unitCount = int.Parse(instDatas[0]);
                            if (unitCount > 0)
                            {
                                units = new JJR_Unit[unitCount];

                                for (int j = 0; j < units.Length; ++j)
                                {
                                    units[j] = new JJR_Unit();
                                }
                            }
                        }
                        break;
                    }
                case Instruction.INST_SET_NAME:
                    {
                        if (instDatas.Length == 2)
                        {
                            int unitIndex = int.Parse(instDatas[0]);
                            string name = instDatas[1];
                            JJR_Unit unit = GetUnit(unitIndex);
                            if (unit != null)
                            {
                                unit.SetName(name);
                            }
                        }
                        break;
                    }
                case Instruction.INST_SET_HP:
                    if (instDatas.Length == 2)
                    {
                        int unitIndex = int.Parse(instDatas[0]);
                        int hp = int.Parse(instDatas[1]);
                        JJR_Unit unit = GetUnit(unitIndex);
                        if (unit != null)
                        {
                            unit.SetHp(hp);
                        }
                    }
                    break;
                case Instruction.INST_SET_POWER:
                    if (instDatas.Length == 2)
                    {
                        int unitIndex = int.Parse(instDatas[0]);
                        int power = int.Parse(instDatas[1]);
                        JJR_Unit unit = GetUnit(unitIndex);
                        if (unit != null)
                        {
                            unit.SetPower(power);
                        }
                    }
                    break;
                case Instruction.INST_ATTACK:
                    if (instDatas.Length == 2)
                    {
                        int attackerIndex = int.Parse(instDatas[0]);
                        int defenderIndex = int.Parse(instDatas[1]);

                        JJR_Unit attacker = GetUnit(attackerIndex);
                        JJR_Unit defender = GetUnit(defenderIndex);
                        if (attacker != null && defender != null)
                        {
                            attacker.Attack(defender);
                        }
                    }
                    break;
                default:
                    continue;
            }

        }
    }

    JJR_Unit GetUnit(int unitIndex)
    {
        if (unitIndex < 0 || unitIndex >= units.Length)
        {
            return null;
        }

        return units[unitIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
