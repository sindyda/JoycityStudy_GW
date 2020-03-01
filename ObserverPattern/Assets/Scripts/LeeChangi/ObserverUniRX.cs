using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

namespace ObserverUniRXVersion
{
    public class MonsterProperty
    {
        public ReactiveProperty<int> HP { get; private set; }
        public ReactiveProperty<int> Attack { get; private set; }

        public MonsterProperty(int hp, int at)
        {
            HP = new ReactiveProperty<int>(hp);
            Attack = new ReactiveProperty<int>(at);
        }
    }

    public class Monster
    {
        public MonsterProperty info { get; private set; }

        public Monster()
        {
            info = new MonsterProperty(100, 10);
        }

        public void Damage(int dmg)
        {
            info.HP.Value -= dmg;
        }
    }

    public class ObserverUniRX : MonoBehaviour
    {

        Monster monster = new Monster();
        // Start is called before the first frame update
        void Start()
        {
            monster.info.HP.Subscribe(x =>
            {
                Debug.Log($"HP Value : {x}");
            });

            monster.Damage(10);
            monster.Damage(20);
            monster.Damage(40);
        }

    }


}


