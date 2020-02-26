using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_ObserverPattern : MonoBehaviour
{
    public KMS_ObserverPattern nextOb = null;
    public UIType type;

    public virtual void Notify(Event type)
    {

    }
}