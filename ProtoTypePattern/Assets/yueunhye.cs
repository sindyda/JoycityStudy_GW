using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class yueunhye : MonoBehaviour
{
    public class Spawner
    {
        public Spawner()
        {

        }
    }

    public class SpawnerFor<T> : Spawner where T : Monster, new()
    {
        public T SpawnMonster ()
        {
            return new T();
        }
    }

    public class Monster
    {
        protected string _name;
        protected int _health;
        protected int _speed;

        protected Monster()
        {
            _name = "Monster";
        }

        public virtual string Debug()
        {
            return string.Format("Name:{0}, Health({1}), Speed({2})", _name, _health, _speed);
        }
    }

    public class Warrior : Monster
    {
        public int _shield;
        public Warrior()
        {
            _name = "Warrior";
            _health = 10;
            _speed = 3;

            _shield = 20;
        }
        public override string Debug()
        {
            return base.Debug() + string.Format("Shield:{0}", _shield);
        }
    }

    public class Archer : Monster
    {
        public int _bowPower;
        public Archer()
        {
            _name = "Archer";
            _health = 10;
            _speed = 3;

            _bowPower = 10;
        }
        public override string Debug()
        {
            return base.Debug() + string.Format("BowPower:{0}", _bowPower);
        }
    }

    public class Wizard : Monster
    {
        public string _magic;
        public Wizard()
        {
            _name = "Wizard";
            _health = 10;
            _speed = 3;

            _magic = "Fire ball";
        }
        public override string Debug()
        {
            return base.Debug() + string.Format("Magic:{0}", _magic);
        }
    }

    public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var gs = new SpawnerFor<Warrior>();
            text.text = gs?.SpawnMonster()?.Debug();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var gs = new SpawnerFor<Archer>();
            text.text = gs?.SpawnMonster()?.Debug();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            var gs = new SpawnerFor<Wizard>();
            text.text = gs?.SpawnMonster()?.Debug();
        }
    }
}