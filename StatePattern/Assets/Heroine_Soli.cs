using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HEROINE_IMAGE_TYPE
{
    IMAGE_STANDING,
    IMAGE_JUMPING,
    IMAGE_DUCKING,
    IMAGE_DIVING
}

public enum HEROINE_EQUIP_TYPE
{
    IMAGE_BASIC,
    IMAGE_SWORD,
}

public enum KEY_TYPE
{
    PRESS_DOWN,
    RELEASE_DOWN,
    PRESS_B,
    PRESS_RightArrow,
    RELEASE_RightArrow,
    PRESS_A,
}

public class Heroine_Soli : MonoBehaviour
{
    private HeroineState_Soli state_ = null;
    private HeroineState_Soli equip_ = null;

    void Start()
    {
        state_ = new StandingState_Soli();
        equip_ = new BasicState_Soli();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            handleInput(KEY_TYPE.PRESS_DOWN);
        else if (Input.GetKeyUp(KeyCode.DownArrow))
            handleInput(KEY_TYPE.RELEASE_DOWN);
        else if (Input.GetKeyDown(KeyCode.B))
            handleInput(KEY_TYPE.PRESS_B);

        else if (Input.GetKeyDown(KeyCode.A))
            handleInput(KEY_TYPE.PRESS_A);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            handleInput(KEY_TYPE.PRESS_RightArrow);
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            handleInput(KEY_TYPE.RELEASE_RightArrow);

        HeroineState_Soli state = state_?.update(this);
        if (state != null)
        {
            state_ = state;
            state_.enter(this);

            state_.update(this);
        }
        equip_?.update(this);
    }

    public void handleInput(KEY_TYPE input)
    {
        HeroineState_Soli state = state_?.handleInput(this, input);
        if (state != null)
        {
            state_ = state;
            state_.enter(this);
        }

        HeroineState_Soli equip = equip_?.handleInput(this, input);
        if (equip != null)
        {
            equip_ = equip;
            equip_.enter(this);
        }
    }

    public void setImage(HEROINE_IMAGE_TYPE imageType)
    {
        switch (imageType)
        {
            case HEROINE_IMAGE_TYPE.IMAGE_STANDING:
                Debug.Log("서 있는 상태");
                break;
            case HEROINE_IMAGE_TYPE.IMAGE_JUMPING:
                Debug.Log("점프 상태");
                break;
            case HEROINE_IMAGE_TYPE.IMAGE_DUCKING:
                Debug.Log("엎드려 있는 상태");
                break;
            case HEROINE_IMAGE_TYPE.IMAGE_DIVING:
                Debug.Log("내려찍기 상태");
                break;
        }
    }

    public void setImage_equip(HEROINE_EQUIP_TYPE equipType)
    {
        switch (equipType)
        {
            case HEROINE_EQUIP_TYPE.IMAGE_BASIC:
                Debug.Log("아무 무기 없음 맨 주먹");
                break;
            case HEROINE_EQUIP_TYPE.IMAGE_SWORD:
                Debug.Log("검을 들고 있음");
                break;
        }
    }

    public void superBomb()
    {
        Debug.Log("氣ㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣ");
    }

    public void walking()
    {
        Debug.Log("걷는 중...");
    }
}
