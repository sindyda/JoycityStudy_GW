using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator
{
    private static Audio_soli service_;

    public static Audio_soli GetAudio()
    {
        Debug.Assert(service_ != null);

        return service_;
    }

    public static void provide(Audio_soli service)
    {
        service_ = service;
    }
}

public class Audio_soli
{
    public virtual void playSound(int soundID)
    {
        
    }

    public virtual void stopSound(int soundID)
    {

    }

    public virtual void stopAllSound()
    {

    }
}

public class ConsoleAudio_soli : Audio_soli
{
    public override void playSound(int soundID)
    {
        Debug.Log("ConsoleAudio " + soundID + " play");
    }

    public override void stopSound(int soundID)
    {
        Debug.Log("ConsoleAudio " + soundID + " stop");
    }

    public override void stopAllSound()
    {
        Debug.Log("ConsoleAudio stop all sound");
    }
}

public class LoggedAudio_soli : Audio_soli
{
    private Audio_soli wrappde_;

    public LoggedAudio_soli(Audio_soli wrappde)
    {
        wrappde_ = wrappde;
    }

    public override void playSound(int soundID)
    {
        Debug.Log("로그 사운드 출력");
        wrappde_.playSound(soundID);
    }

    public override void stopSound(int soundID)
    {
        Debug.Log("로그 사운드 중지");
        wrappde_.stopSound(soundID);
    }

    public override void stopAllSound()
    {
        Debug.Log("로그 모든 사운드 중지");
        wrappde_.stopAllSound();
    }
}