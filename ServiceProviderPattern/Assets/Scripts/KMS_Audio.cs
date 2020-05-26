using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_Audio
{
    public virtual void PlaySound(int soundID) { }
    public virtual void StopSound(int soundId) { }
    public virtual void StopAllSound() { }
}

public class ConsolAudio : KMS_Audio
{

}

