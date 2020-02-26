using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RockPaperScissors
{
    Rock = 0,
    Paper = 1,
    Scissors = 2,
}

public class JJR_ObserverPattern : MonoBehaviour
{
    public List<JJR_Observer> observers = new List<JJR_Observer>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Nofify(RockPaperScissors.Scissors);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Nofify(RockPaperScissors.Rock);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Nofify(RockPaperScissors.Paper);
        }
    }

    void Nofify(RockPaperScissors type)
    {
        for (int i = 0; i < observers.Count; ++i)
        {
            var observer = observers[i];
            if (observer != null)
            {
                observer.onNofity(type);
            }
        }
    }
}

