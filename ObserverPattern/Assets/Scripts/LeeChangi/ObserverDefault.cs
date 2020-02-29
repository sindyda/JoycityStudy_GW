using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverDeafultVersion
{

    public interface IObserverDefault<T>
    {
        void onNotify(in T value);
    }


    public interface IObservableDefault<T>
    {
        void AddObserver(IObserverDefault<T> observer);
        void RemoveObserver(IObserverDefault<T> observer);
    }



    public struct CharacterInfo
    {
        public int HP;
    }


    public class Character : IObservableDefault<CharacterInfo>
    {
        CharacterInfo info;
        public Character(int hp)
        {
            info = new CharacterInfo()
            {
                HP = hp,
            };
        }

        public void Damage(int dmg)
        {
            info.HP -= dmg;

            Notify();
        }


        private List<IObserverDefault<CharacterInfo>> Observers = new List<IObserverDefault<CharacterInfo>>();

        public void AddObserver(IObserverDefault<CharacterInfo> observer)
        {
            Observers.Add(observer);
            observer.onNotify(info);
        }

        public void RemoveObserver(IObserverDefault<CharacterInfo> observer)
        {
            Observers.Remove(observer);
        }

        private void Notify()
        {
            foreach(var item in Observers)
            {
                item.onNotify(info);
            }
        }

    }

    public class CharacterManager
    {
        private static CharacterManager instance = null;
        public static CharacterManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CharacterManager();
                }
                return instance;
            }
        }

        public CharacterManager()
        {
            mychar = new Character(100);
        }

        public Character mychar { get; private set; }
    }


    

    public class ObserverDefault : MonoBehaviour, IObserverDefault<CharacterInfo>
    {
        public Text hpText;

        public void onNotify(in CharacterInfo value)
        {
            Debug.Log(value);
            if (hpText)
            {
                
                hpText.text = value.HP.ToString();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            CharacterManager.Instance.mychar.AddObserver(this);


            CharacterManager.Instance.mychar.Damage(10);
            CharacterManager.Instance.mychar.Damage(10);
            CharacterManager.Instance.mychar.Damage(10);
            CharacterManager.Instance.mychar.Damage(10);
            CharacterManager.Instance.mychar.Damage(10);
            CharacterManager.Instance.mychar.Damage(10);
            CharacterManager.Instance.mychar.Damage(10);
        }

        private void OnDestroy()
        {
            CharacterManager.Instance.mychar.RemoveObserver(this);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }



}
