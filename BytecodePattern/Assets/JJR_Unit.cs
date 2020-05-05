using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJR_Unit
{
    private string name = "";
    private int hp = 0;
    private int power = 0;

    public void SetName(string name)
    {
        this.name = name;

        Debug.Log(string.Format("Set Name : {0}", name));
    }

    public void SetHp(int hp)
    {
        this.hp = hp;

        Debug.Log(string.Format("{0} : Hp = {1}", name, hp));
    }

    public void SetPower(int power)
    {
        this.power = power;

        Debug.Log(string.Format("{0} : Power = {1}", name, power));
    }

    public void Attack(JJR_Unit defender)
    {
        if (IsDead())
        {
            Debug.Log(string.Format("Attacker {0} is Dead", name));
            return;
        }

        if (defender.IsDead())
        {
            Debug.Log(string.Format("Defender {0} is Dead", defender.name));
            return;
        }

        defender.hp -= power;

        Debug.Log(string.Format("Attacker : {0}, Power - {1} > defender : {2}, Hp - {3}", name, power, defender.name, defender.hp));
        if (defender.IsDead())
        {
            defender.hp = 0;

            Debug.Log("Game Over!!");
            Debug.Log(string.Format("Winner : {0}, Hp - {1}", name, hp));
            Debug.Log(string.Format("Loser : {0}, Hp - {1}", defender.name, defender.hp));
        }
    }

    public bool IsDead()
    {
        return hp <= 0;
    }
}
