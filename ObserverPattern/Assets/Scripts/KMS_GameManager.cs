using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    Status,
    Inventory,
    Equip,
}

public class KMS_GameManager : MonoBehaviour
{
    public KMS_ObserverPattern statusUI;
    public KMS_ObserverPattern InventoryUI;
    public KMS_ObserverPattern EquipUI;

    KMS_Subject subject = new KMS_Subject();

    public void OnClickOpen(int type)
    {
        switch (type)
        {
            case 0:
                statusUI.gameObject.SetActive(true);
                subject.AddObserver(statusUI);
                break;
            case 1:
                InventoryUI.gameObject.SetActive(true);
                subject.AddObserver(InventoryUI);
                break;
            case 2:
                EquipUI.gameObject.SetActive(true);
                subject.AddObserver(EquipUI);
                break;
        }
    }

    public void OnClickClose(int type)
    {
        switch (type)
        {
            case 0:
                statusUI.gameObject.SetActive(false);
                subject.RemoveObserver(statusUI);
                break;
            case 1:
                InventoryUI.gameObject.SetActive(false);
                subject.RemoveObserver(InventoryUI);
                break;
            case 2:
                EquipUI.gameObject.SetActive(false);
                subject.RemoveObserver(EquipUI);
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            // 캐릭터 채인지
            Debug.Log("캐릭터에 변화가 있습니다.");
            subject.notify(Event.StatusChange);

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            // 아이템 획득
            Debug.Log("아이템을 획득 했습니다.");
            subject.notify(Event.GetItem);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            // 장비 장착
            Debug.Log("장비를 장착합니다.");
            subject.notify(Event.Equipment);
        }
    }
}
