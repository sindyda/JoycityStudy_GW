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
        // 충돌 체크
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KMS_Unit unit = obj.GetComponent<KMS_Unit>();
            gridMap.HandleMelee(unit.x, unit.y);
        }
        if( Input.GetKeyUp(KeyCode.Space))
        {
            gridMap.ResetColor();
        }

        // 방향키로 메인 Object 이동
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
