using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo
{
    public int currentScore = 0;
    public bool dirtyFlag = false;
    public Combo nextCombo;

    public Combo(int count, int score)
    {
        currentScore = score;
        dirtyFlag = true;
        nextCombo = null;
    }

    public void UpdateScore(int parentScore, int currentHit, bool reCalcScore)
    {
        reCalcScore |= dirtyFlag;

        if (reCalcScore)
        {
            CalcScore(currentHit, currentScore);
        }

        if (nextCombo == null) return;
        nextCombo.UpdateScore(currentScore, currentHit, reCalcScore);

    }

    void CalcScore(int currentHitCombo, int parentScore)
    {
        KMS_DirtyFlagPattern.CalcCount++;
        dirtyFlag = false;
        if (currentHitCombo % 10 != 0)
            return;

        int bonus = currentHitCombo / 10;
        currentScore = bonus;
    }
}


public class KMS_ComboSystem
{
    int comboScore = 0;
    int comboCount = 0;

    List<Combo> comboList = new List<Combo>();

    public void AddCombo()
    {
        ++comboCount;

        Combo prevCombo = comboList.Count <= 0 ? null : comboList[comboList.Count - 1];

        Combo combo = new Combo(comboCount, comboCount / 10);
        if (prevCombo != null)
        {
            prevCombo.nextCombo = combo;
        }
        comboList.Add(combo);

        if (comboCount % 10 == 0)
        {
            comboList[0].UpdateScore(comboList[0].currentScore, comboCount, true);
        }
        else
        {
            comboList[0].UpdateScore(comboList[0].currentScore, comboCount, false);
        }
    }

    public int GetCurrentScore()
    {
        comboScore = 0;

        for (int i = 0; i < comboList.Count; ++i)
        {
            comboScore += comboList[i].currentScore;
        }

        return comboScore;
    }

    public int GetComboCount()
    {
        return comboCount;
    }

    public void ClearCombo()
    {
        comboScore = 0;
        comboCount = 0;
        comboList.Clear();
    }
}
