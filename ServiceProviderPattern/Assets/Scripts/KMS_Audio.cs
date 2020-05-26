using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Audio
{
    public virtual void PlaySound(int soundID) { }
    public virtual void StopSound(int soundId) { }
    public virtual void StopAllSound() { }
}

public class ConsoleAudio : KMS_Audio
{
    public override void PlaySound(int soundID)
    {
        Debug.Log("Console Audio Play : " + soundID);
    }

    public override void StopAllSound()
    {
    }

    public override void StopSound(int soundId)
    {
    }
}

public class NullAudio : KMS_Audio
{
    public override void PlaySound(int soundID)
    {
        Debug.Log("Null Audio Play : " + soundID);
    }

    public override void StopAllSound()
    {
    }

    public override void StopSound(int soundId)
    {
    }
}

public class LogAudio : KMS_Audio
{
    public override void PlaySound(int soundID)
    {
        Debug.Log("LogAudio Audio Play : " + soundID);
    }

    public override void StopAllSound()
    {
    }

    public override void StopSound(int soundId)
    {
    }
}

