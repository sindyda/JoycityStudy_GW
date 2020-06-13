using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_SpacePartition : MonoBehaviour
{
    public static KMS_Grid gridMap = new KMS_Grid();
    GameObject obj = null;
    private void Start()
    {
        obj = Instantiate(Resources.Load("Cube") as GameObject);
        Camera.main.gameObject.transform.parent = obj.transform;
    }

    private void Update()
    {
        // 공격 키
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gridMap.HandleMelee();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var unit = obj.GetComponent<KMS_Unit>();
            unit.Move(-(Time.deltaTime * 10.0f), 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            var unit = obj.GetComponent<KMS_Unit>();
            unit.Move((Time.deltaTime * 10.0f), 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            var unit = obj.GetComponent<KMS_Unit>();
            unit.Move(0, -(Time.deltaTime * 10.0f));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            var unit = obj.GetComponent<KMS_Unit>();
            unit.Move(0, (Time.deltaTime * 10.0f));
        }
    }

}
