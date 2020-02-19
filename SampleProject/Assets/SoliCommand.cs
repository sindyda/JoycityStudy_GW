using UnityEngine;

public class SoliCommand
{
    public virtual void excute(SoliUnit unit) { }
    public virtual void undo(SoliUnit unit) { }
    public float xBefore = 0;
    public float yBefore = 0;
}

public class UpSoliCommand : SoliCommand
{
    public override void excute(SoliUnit unit)
    {
        xBefore = unit.transform.position.x;
        yBefore = unit.transform.position.y;
        unit.transform.position += Vector3.up;
    }
}

public class DownSoliCommand : SoliCommand
{
    public override void excute(SoliUnit unit)
    {
        xBefore = unit.transform.position.x;
        yBefore = unit.transform.position.y;
        unit.transform.position += Vector3.down;
    }
}

public class RightSoliCommand : SoliCommand
{
    public override void excute(SoliUnit unit)
    {
        xBefore = unit.transform.position.x;
        yBefore = unit.transform.position.y;
        unit.transform.position += Vector3.right;
    }
}

public class LeftSoliCommand : SoliCommand
{
    public override void excute(SoliUnit unit)
    {
        xBefore = unit.transform.position.x;
        yBefore = unit.transform.position.y;
        unit.transform.position += Vector3.left;
    }
}

