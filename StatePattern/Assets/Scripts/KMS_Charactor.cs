using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Charactor : MonoBehaviour
{
    KMS_StatePattern charactorState = null;
    KMS_StatePattern ItemState = null;

    public KMS_Weapon weapon = null;

    private void Start()
    {
        charactorState = new KMS_State_Stand();
        ItemState = new KMS_Equip_Sword();
        ItemState.Enter(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpdateState_Charactor(InputState.INPUT_PRESS_DOWN);
            UpdateState_Item(InputState.INPUT_PRESS_DOWN);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            UpdateState_Charactor(InputState.INPUT_RELEASE_DOWN);
            UpdateState_Item(InputState.INPUT_RELEASE_DOWN);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            UpdateState_Charactor(InputState.INPUT_PRESS_UP);
            UpdateState_Item(InputState.INPUT_PRESS_UP);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            UpdateState_Charactor(InputState.INPUT_PRESS_ATTACK);
            UpdateState_Item(InputState.INPUT_PRESS_ATTACK);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            UpdateState_Charactor(InputState.INPUT_RELEASE_ATTACK);
            UpdateState_Item(InputState.INPUT_RELEASE_ATTACK);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            UpdateState_Charactor(InputState.INPUT_CHANGE_WAEPON_GUN);
            UpdateState_Item(InputState.INPUT_CHANGE_WAEPON_GUN);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            UpdateState_Charactor(InputState.INPUT_CHANGE_WEAPON_SWORD);
            UpdateState_Item(InputState.INPUT_CHANGE_WEAPON_SWORD);
        }

        if (charactorState != null)
        {
            var changeState = charactorState.Update(gameObject);
            if (changeState != null)
            {
                charactorState = changeState;
                charactorState.Enter(gameObject);
            }
        }
    }

    void UpdateState_Charactor(InputState input)
    {
        var state = charactorState.InputHandler(this, input);
        if (state != null)
        {
            charactorState.Exit(gameObject);
            charactorState = state;
            charactorState.Enter(gameObject);
        }
    }

    void UpdateState_Item(InputState input)
    {
        var state = ItemState.InputHandler(this, input);
        if (state != null)
        {
            ItemState.Exit(gameObject);
            ItemState = state;
            ItemState.Enter(gameObject);
        }
    }
}
