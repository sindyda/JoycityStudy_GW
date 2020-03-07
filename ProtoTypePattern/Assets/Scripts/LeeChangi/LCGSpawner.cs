using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeeChangiPrototypeTest
{
    public class LCGSpawner : MonoBehaviour
    {
        public Character1 Character1Base;
        public Monster1 Monster1Base;
        void SpawnMonster()
        {
            var spawnobj = Monster1Base?.Clone();
            SetPosition(spawnobj);
        }

        
        void SpawnCharacter()
        {
            var cloneObj = Spawner.SpawnObject<Character1>(Character1Base);
            SetPosition(cloneObj);
        }

        private void SetPosition(in MonoBehaviour obj)
        {
            obj.transform.SetParent(transform, false);
            obj.transform.localPosition = new Vector3(0, 0, 0);
            obj.gameObject.SetActive(true);
        }


        private void Start()
        {
            SpawnCharacter();
            SpawnMonster();
        }
    }


    public class Spawner
    {
        public static T SpawnObject<T>(T baseObject) where T : MonoBehaviour
        {
            var result = GameObject.Instantiate(baseObject.gameObject);
            if (result == null)
            {
                return default(T);
            }
            return result.GetComponent<T>();
        }
    }
}