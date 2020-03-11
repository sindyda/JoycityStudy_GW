using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeeChangiPrototypeTest
{
    public class Monster1 : MonoBehaviour
    {
        public Monster1 Clone()
        {
            var result = Instantiate(gameObject);
            if (result == null)
            {
                return null;
            }

            return result.GetComponent<Monster1>();
        }
    }

}