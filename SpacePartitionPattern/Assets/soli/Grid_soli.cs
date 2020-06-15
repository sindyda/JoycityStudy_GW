using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_soli
{
    public Grid_soli()
    {
        for (int x = 0; x < NUM_CELLS; ++x)
            for (int y = 0; y < NUM_CELLS; ++y)
                cells_[x, y] = null;
    }

    public void add(Unit_soli unit)
    {
        int cellX = (int)(unit.x_ / CELL_SIZE);
        int cellY = (int)(unit.y_ / CELL_SIZE);

        unit.prev_ = null;
        unit.next_ = cells_[cellX, cellY];
        cells_[cellX, cellY] = unit;

        if(unit.next_ != null)
        {
            unit.next_.prev_ = unit;
        }
    }

    public void move(Unit_soli unit, float x, float y)
    {
        int oldCellX = (int)(unit.x_ / CELL_SIZE);
        int oldCellY = (int)(unit.y_ / CELL_SIZE);

        int cellX = (int)(x / CELL_SIZE);
        int cellY = (int)(y / CELL_SIZE);

        unit.x_ = x;
        unit.y_ = y;

        if (oldCellX == cellX && oldCellY == cellY)
            return;

        if (unit.prev_ != null)
            unit.prev_.next_ = unit.next_;

        if (unit.next_ != null)
            unit.next_.prev_ = unit.prev_;

        if (cells_[oldCellX, oldCellY] == unit)
            cells_[oldCellY, oldCellY] = unit.next_;

        add(unit);
    }

    public void handleMedee()
    {
        for (int x = 0; x < NUM_CELLS; ++x)
            for (int y = 0; y < NUM_CELLS; ++y)
                handleCell(cells_[x, y]);
    }

    public void handleCell(Unit_soli unit)
    {
        while(unit != null)
        {
            Unit_soli other = unit.next_;
            while (other != null)
            {
                if(unit.x_ == other.x_ && unit.y_ == other.y_)
                {
                    handleAttack(unit, other);
                }
                other = other.next_;
            }
            unit = unit.next_;
        }
    }

    public void handleAttack(Unit_soli ally, Unit_soli enemy)
    {
        Debug.Log("공격!");
    }

    const int NUM_CELLS = 10;
    const int CELL_SIZE = 2;

    private Unit_soli[,] cells_ = new Unit_soli[NUM_CELLS, NUM_CELLS];
}
