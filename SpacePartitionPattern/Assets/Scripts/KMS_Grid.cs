using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Grid
{
    public const int NUM_CELL = 4;
    public const int CELL_SIZE = 2;
    public const float ATTACK_DISTANCE = 1.5f;

    // 모든 Unit은 Add를 통해 등록이 되어야 함
    private KMS_Unit[,] cells = new KMS_Unit[NUM_CELL, NUM_CELL];

    public void Add(KMS_Unit unit)
    {
        int cellX = (int)(unit.x / CELL_SIZE);
        int cellY = (int)(unit.y / CELL_SIZE);

        unit.prev = null;
        unit.next = cells[cellX, cellY];
        cells[cellX, cellY] = unit;

        if (unit.next != null)
        {
            unit.next.prev = unit;
        }
    }

    public void HandleMelee(float unitX, float unitY)
    {
        int cellX = (int)(unitX / CELL_SIZE);
        int cellY = (int)(unitY / CELL_SIZE);

        // 내 유닛이 있는 곳만 검색
        HandleCell(cellX, cellY);
    }

    void HandleCell(int x, int y)
    {
        KMS_Unit unit = cells[x, y];

        while (unit != null)
        {
            HandleUnit(unit, unit.next);

            if (x > 0) HandleUnit(unit, cells[x - 1, y]);
            if (y > 0) HandleUnit(unit, cells[x, y - 1]);
            if (x > 0 && y > 0) HandleUnit(unit, cells[x - 1, y - 1]);
            if (x > 0 && y < NUM_CELL - 1) HandleUnit(unit, cells[x - 1, y + 1]);

            if (x < NUM_CELL - 1) HandleUnit(unit, cells[x + 1, y]);
            if (y < NUM_CELL - 1) HandleUnit(unit, cells[x, y + 1]);
            if (x < NUM_CELL - 1 && y < NUM_CELL - 1) HandleUnit(unit, cells[x + 1, y + 1]);
            if (x < NUM_CELL - 1 && y > 0) HandleUnit(unit, cells[x + 1, y - 1]);

            unit = unit.next;
        }
    }

    void HandleAttack(KMS_Unit attackUnit, KMS_Unit defenceUnit)
    {
        if (Vector3.Distance(attackUnit.transform.localPosition, defenceUnit.transform.localPosition) <= ATTACK_DISTANCE)
        {
            // 충돌 성공 시 로그 출력
            Debug.Log(defenceUnit.gameObject.name + "&" + attackUnit.gameObject.name + " Hit");
        }
    }

    public void Move(KMS_Unit unit, float x, float y)
    {
        // 위치 정보를 업데이트
        int oldCellX = (int)(unit.x / CELL_SIZE);
        int oldCellY = (int)(unit.y / CELL_SIZE);

        int cellX = (int)(x / CELL_SIZE);
        int cellY = (int)(y / CELL_SIZE);

        unit.x = x;
        unit.y = y;
        // 여기까지가 위치 정보 수정이고

        // 여기서 부터는 검색 cell 위치 수정
        if (oldCellX == cellX && oldCellY == cellY)
        {
            return;
        }

        if (unit.prev != null)
        {
            unit.prev.next = unit.next;
        }

        if (unit.next != null)
        {
            unit.next.prev = unit.prev;
        }

        if (cells[oldCellX, oldCellY] == unit)
        {
            cells[oldCellX, oldCellY] = unit.next;
        }

        Add(unit);

        Debug.Log(string.Format("Current Cell Pos : {0}, {1}", cellX, cellY));
    }

    public void HandleUnit(KMS_Unit unit, KMS_Unit other)
    {
        while (other != null)
        {
            if (Distance(unit, other) < ATTACK_DISTANCE)
            {
                HandleAttack(unit, other);
            }
            other = other.next;
        }
    }

    float Distance(KMS_Unit unit, KMS_Unit other)
    {
        // 거리 계산, 대상 오브젝트들은 컬러를 변경해서 눈에 잘 보이게 
        unit.UpdateFindColor();
        other.UpdateFindColor();
        return Vector3.Distance(unit.transform.localPosition, other.transform.localPosition);
    }

    public void ResetColor()
    {
        for (int x = 0; x < NUM_CELL; ++x)
        {
            for (int y = 0; y < NUM_CELL; ++y)
            {
                KMS_Unit unit = cells[x, y];
                while (unit != null )
                {
                    unit.UpdateColor();
                    unit = unit.next;
                }
            }
        }
    }
}
