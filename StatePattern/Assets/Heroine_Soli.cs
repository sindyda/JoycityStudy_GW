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

public enum KEY_TYPE
{
    RELEASE_DOWN,
    PRESS_DOWN,
    PRESS_B,
}

public class Heroine_Soli : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
            handleInput(KEY_TYPE.PRESS_DOWN);
        else if (Input.GetKeyUp(KeyCode.DownArrow))
            handleInput(KEY_TYPE.RELEASE_DOWN);
        else if (Input.GetKeyUp(KeyCode.B))
            handleInput(KEY_TYPE.PRESS_B);

        state_.update(this);
    }

    private HeroineState_Soli state_ = new StandingState_Soli();

    public void handleInput(KEY_TYPE input)
    {
        HeroineState_Soli state = state_.handleInput(this, input);
        if (state != null)
        {
            state_ = state;
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

    public void superBomb()
    {
        Debug.Log("기ㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣㅣ");
    }

    public void setStaningState()
    {
        setImage(HEROINE_IMAGE_TYPE.IMAGE_STANDING);
        state_ = new StandingState_Soli();
    }
}
