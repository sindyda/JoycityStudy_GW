using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeeChangiPrototypeTest
{
    public interface IPrototype
    {

    }


    public class Prototype : IPrototype
    {
        private List<Prototype> prototype = new List<Prototype>(); 

        public Prototype()
        {

        }
    }
    
    public class SpawnTest
    {

    }


}

