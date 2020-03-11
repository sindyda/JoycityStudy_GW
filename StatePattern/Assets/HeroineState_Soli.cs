using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroineState_Soli
{
    public virtual HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        return null;
    }

    public virtual void update(Heroine_Soli heroine)
    {

    }
}

public class DuckingState_Soli : HeroineState_Soli
{
    const int MAX_CHARGE = 100;

    public DuckingState_Soli()
    {
        chargeTime_ = 0;
    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if(input == KEY_TYPE.RELEASE_DOWN)
        {
            heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_STANDING);
            return new StandingState_Soli();
        }

        return null;
    }

    public override void update(Heroine_Soli heroine)
    {
        chargeTime_++;
        if (chargeTime_ > MAX_CHARGE)
        {
            chargeTime_ = 0;
            heroine.superBomb();
        }
    }

    private int chargeTime_;
}

public class StandingState_Soli : HeroineState_Soli
{
    public StandingState_Soli()
    {

    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.PRESS_DOWN)
        {
            heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_DUCKING);
            return new DuckingState_Soli();
        }
        else if(input == KEY_TYPE.PRESS_B)
        {
            heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_JUMPING);
            return new JumpingState_Soli();
        }

        return null;
    }

    public override void update(Heroine_Soli heroine)
    {
        base.update(heroine);
    }
}

public class JumpingState_Soli : HeroineState_Soli
{
    const int MAX_JUMPING = 100;

    public JumpingState_Soli()
    {

    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.PRESS_DOWN)
        {
            heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_DIVING);
            return new DvingState_Soli();
        }

        return null;
    }

    public override void update(Heroine_Soli heroine)
    {
        jumpTime_++;
        if (jumpTime_ > MAX_JUMPING)
        {
            jumpTime_ = 0;
            heroine.setStaningState();
        }
    }

    private int jumpTime_;
}

public class DvingState_Soli : HeroineState_Soli
{
    const int MAX_DIVING = 100;

    public DvingState_Soli()
    {

    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.PRESS_DOWN)
        {
            heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_STANDING);
            return new StandingState_Soli();
        }

        return null;
    }

    public override void update(Heroine_Soli heroine)
    {
        divingTime_++;
        if (divingTime_ > MAX_DIVING)
        {
            divingTime_ = 0;
            heroine.setStaningState();
        }
    }

    private int divingTime_;
}
