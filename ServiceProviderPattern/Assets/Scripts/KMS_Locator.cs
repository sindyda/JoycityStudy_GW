using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Locator
{
    public static void Init()
    {
        service = nullAudio;
    }

    public static KMS_Audio GetAudio()
    {
        return service;
    }

    public static void Provide(KMS_Audio _service)
    {
        if (_service == null)
            service = nullAudio;
        else
            service = _service;
    }

    static KMS_Audio service;
    static NullAudio nullAudio = new NullAudio();

}
