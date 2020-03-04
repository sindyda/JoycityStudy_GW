using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Soli
{
    public virtual Monster_Soli clone()
    {
        return new Monster_Soli();
    }

    public int health = 0;
    public int speed = 0;
}

public class Ghost_Soli : Monster_Soli
{
    public Ghost_Soli(int health, int speed)
    {
        this.health = health;
        this.speed = speed;
    }

    public override Monster_Soli clone()
    {
        return new Ghost_Soli(health, speed);
    }
}

public class Demon_Soli : Monster_Soli
{
    public Demon_Soli(int health, int speed)
    {
        this.health = health;
        this.speed = speed;
    }

    public override Monster_Soli clone()
    {
        return new Demon_Soli(health, speed);
    }
}

public class Spawner_Soli
{
    public Spawner_Soli(Monster_Soli prototype)
    {
        prototype_ = prototype;
    }

    public virtual Monster_Soli spawnMonster()
    {
        return prototype_.clone();
    }

    private Monster_Soli prototype_;
}