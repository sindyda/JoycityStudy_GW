using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subject_Soli : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        addObserver(new Audio_Soli());
        addObserver(new Achievement_Soli());
    }

    // Update is called once per frame
    void Update()
    {
        switch (Input.inputString)
        {
            case "A":
                notify(this, EventType_Soli.EventType_Soli_A);
                break;
            case "B":
                notify(this, EventType_Soli.EventType_Soli_B);
                break;
            case "C":
                notify(this, EventType_Soli.EventType_Soli_C);
                break;
        }
    }

    public Text achivementText;
    public Text audioText;

    List<Observer_Soli> observer_ = new List<Observer_Soli>();
    
    void notify(Subject_Soli entity, EventType_Soli eventType)
    {
        for(int i = 0; i < observer_.Count; ++i)
        {
            observer_[i].onNotify(entity, eventType);
        }
    }

    void addObserver(Observer_Soli observer)
    {
        observer_.Add(observer);
    }

    void removeObserver(Observer_Soli observer)
    {
        observer_.Remove(observer);
    }
}
