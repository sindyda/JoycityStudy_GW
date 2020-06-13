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
        KMS_SpacePartition.gridMap.Add(this);
        UpdateColor();

    }

    public float x, y;
    //public KMS_Grid grid;
    public KMS_Unit prev;
    public KMS_Unit next;

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

    void UpdateColor()
    {
        var cubeRenderer = gameObject.GetComponentInChildren<Renderer>();
        if (cubeRenderer != null)
        {
            int cellX = (int)(x / KMS_Grid.CELL_SIZE);
            int cellY = (int)(y / KMS_Grid.CELL_SIZE);

            cubeRenderer.material.SetColor("_Color", new Color(cellX / (float)KMS_Grid.CELL_SIZE,
                cellY / (float)KMS_Grid.CELL_SIZE, 0));
        }
    }
}
