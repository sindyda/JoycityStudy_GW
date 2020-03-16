using UnityEngine;

public class HeroineState_Soli
{
    public virtual HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        return null;
    }

    public virtual HeroineState_Soli update(Heroine_Soli heroine)
    {
        return null;
    }

    public virtual void enter(Heroine_Soli heroine)
    {

    }
}

public class OnGroundState_Soli : HeroineState_Soli
{
    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.PRESS_DOWN)
        {
            return new DuckingState_Soli();
        }
        else if (input == KEY_TYPE.PRESS_B)
        {
            return new JumpingState_Soli();
        }
        else if (input == KEY_TYPE.PRESS_RIGHT)
        {
            return new WalkState_Soli();
        }
        else if (input == KEY_TYPE.PRESS_LEFT)
        {
            return new RunState_Soli();
        }

        return null;
    }

    public override HeroineState_Soli update(Heroine_Soli heroine)
    {
        return null;
    }

    public override void enter(Heroine_Soli heroine)
    {

    }
}

public class StandingState_Soli : OnGroundState_Soli
{
    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        return base.handleInput(heroine, input);
    }

    public override void enter(Heroine_Soli heroine)
    {
        heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_STANDING);
    }
}

public class WalkState_Soli : OnGroundState_Soli
{
    float walkingStateUpdateTime = 0.7f;
    
    public WalkState_Soli()
    {
        walkTime_ = 0;
    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.RELEASE_RIGHT)
        {
            return new StandingState_Soli();
        }
        else
        {
            return base.handleInput(heroine, input);
        }
    }

    public override HeroineState_Soli update(Heroine_Soli heroine)
    {
        walkTime_ += Time.deltaTime;
        if (walkTime_ > walkingStateUpdateTime)
        {
            walkTime_ = 0;
            heroine.walking();
        }

        return null;
    }

    private float walkTime_;
}

public class RunState_Soli : OnGroundState_Soli
{
    float runingStateUpdateTime = 0.3f;

    public RunState_Soli()
    {
        runTime_ = 0;
    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.RELEASE_LEFT)
        {
            return new StandingState_Soli();
        }
        else
        {
            return base.handleInput(heroine, input);
        }
    }

    public override HeroineState_Soli update(Heroine_Soli heroine)
    {
        runTime_ += Time.deltaTime;
        if (runTime_ > runingStateUpdateTime)
        {
            runTime_ = 0;
            heroine.runing();
        }

        return null;
    }
    
    private float runTime_;
}

public class DuckingState_Soli : HeroineState_Soli
{
    const int MAX_CHARGE_SECOND = 1;

    public DuckingState_Soli()
    {
        chargeTime_ = 0;
    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.RELEASE_DOWN)
        {
            return new StandingState_Soli();
        }

        return null;
    }

    public override HeroineState_Soli update(Heroine_Soli heroine)
    {
        chargeTime_ += Time.deltaTime;
        if (chargeTime_ > MAX_CHARGE_SECOND)
        {
            chargeTime_ = 0;
            heroine.superBomb();
        }

        return null;
    }

    public override void enter(Heroine_Soli heroine)
    {
        heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_DUCKING);
    }

    private float chargeTime_;
}

public class JumpingState_Soli : HeroineState_Soli
{
    const int MAX_JUMPING_SECOND = 1;

    public JumpingState_Soli()
    {
        jumpTime_ = 0;
    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.PRESS_DOWN)
        {
            return new DvingState_Soli();
        }

        return null;
    }

    public override HeroineState_Soli update(Heroine_Soli heroine)
    {
        jumpTime_ += Time.deltaTime;
        if (jumpTime_ > MAX_JUMPING_SECOND)
        {
            jumpTime_ = 0;
           
            return new StandingState_Soli();
        }

        return null;
    }

    public override void enter(Heroine_Soli heroine)
    {
        heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_JUMPING);
    }

    private float jumpTime_;
}

public class DvingState_Soli : HeroineState_Soli
{
    const int MAX_DIVING_SECOND = 1;

    public DvingState_Soli()
    {
        divingTime_ = 0;
    }

    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.PRESS_DOWN)
        {
            return new StandingState_Soli();
        }

        return null;
    }

    public override HeroineState_Soli update(Heroine_Soli heroine)
    {
        divingTime_ += Time.deltaTime;
        if (divingTime_ > MAX_DIVING_SECOND)
        {
            divingTime_ = 0;

            return new StandingState_Soli();
        }

        return null;
    }

    public override void enter(Heroine_Soli heroine)
    {
        heroine.setImage(HEROINE_IMAGE_TYPE.IMAGE_DIVING);
    }

    private float divingTime_;
}

// 장비 - 맨몸
public class BasicState_Soli : HeroineState_Soli
{
    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.PRESS_A)
        {
            return new SwordState_Soli();
        }

        return null;
    }

    public override void enter(Heroine_Soli heroine)
    {
        heroine.setImage_equip(HEROINE_EQUIP_TYPE.IMAGE_BASIC);
    }
}

// 장비 - 검
public class SwordState_Soli : HeroineState_Soli
{
    public override HeroineState_Soli handleInput(Heroine_Soli heroine, KEY_TYPE input)
    {
        if (input == KEY_TYPE.PRESS_A)
        {
            return new BasicState_Soli();
        }

        return null;
    }
    
    public override void enter(Heroine_Soli heroine)
    {
        heroine.setImage_equip(HEROINE_EQUIP_TYPE.IMAGE_SWORD);
    }
}
