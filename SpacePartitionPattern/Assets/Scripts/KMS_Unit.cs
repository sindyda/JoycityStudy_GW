using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Unit : MonoBehaviour
{
    private void Start()
    {
        x = transform.localPosition.x;
        y = transform.localPosition.y;
        prev = null;
        next = null;
        // 생성이 완료 되면 gridMap에 넣는게 가장 중요
        KMS_SpacePartition.gridMap.Add(this);
        UpdateColor();
    }

    public float x, y;
    public KMS_Unit prev;
    public KMS_Unit next;
    public Color findColor = new Color(255, 255, 255);
    Renderer cubeRenderer = null;
    Color myColor;
    Color crashColor = new Color(0, 0, 255);

    // 키 입력을 받으면 이동
    public void Move(float _x, float _y)
    {
        if ((x + _x) >= KMS_Grid.NUM_CELL * KMS_Grid.CELL_SIZE)
            return;
        if ((x + _x) < 0)
            return;
        if ((y + _y) >= KMS_Grid.NUM_CELL * KMS_Grid.CELL_SIZE)
            return;
        if ((y + _y) < 0)
            return;

        KMS_SpacePartition.gridMap.Move(this, x + _x, y + _y);

        transform.localPosition = new Vector3(x, y, transform.localPosition.z);

        UpdateColor();
    }
    
    // 위치에 따른 컬러 표기 
    public void UpdateColor()
    {
        if (cubeRenderer == null)
            cubeRenderer = gameObject.GetComponentInChildren<Renderer>();

        if (cubeRenderer != null)
        {
            int cellX = (int)(x / KMS_Grid.CELL_SIZE);
            int cellY = (int)(y / KMS_Grid.CELL_SIZE);

            myColor = new Color(cellX / (float)KMS_Grid.CELL_SIZE,
                cellY / (float)KMS_Grid.CELL_SIZE, 0);

            cubeRenderer.material.SetColor("_Color", myColor);
        }
    }

    // 검사 대상자에 따른 컬러 표기
    public void UpdateFindColor()
    {
        if (cubeRenderer == null)
            cubeRenderer = gameObject.GetComponentInChildren<Renderer>();

        if (cubeRenderer != null)
        {
            cubeRenderer.material.SetColor("_Color", findColor);
        }
    }
}
