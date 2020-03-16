using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeeChangiPrototypeTest
{
    public enum RecycleKind
    {
        Object1,
        Object2,

        RecycleMax,
    }

    public class RecycleManager : MonoBehaviour
    {
        public RecyclePrefab[] basePrefabs = new RecyclePrefab[(int)RecycleKind.RecycleMax];
        static List<GameObject>[] recylces = new List<GameObject>[(int)RecycleKind.RecycleMax];

        public void Initialize()
        {
            int maxKind = (int)RecycleKind.RecycleMax;
            for (int i =0;i< maxKind; i++)
            {
                recylces[i] = new List<GameObject>();
                
            }
        }

        //public RecyclePrefab AcquirInstance<RecyclePrefab>(RecycleKind kind)
        //{
            
        //}
    }

}