using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceProvider_soli : MonoBehaviour
{
    ConsoleAudio_soli audio_ = null;

    private void Start()
    {
        audio_ = new ConsoleAudio_soli();
        Locator.provide(audio_);
        enableAudioLogging();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Locator.GetAudio().playSound(1);
        else if (Input.GetKeyDown(KeyCode.B))
            Locator.GetAudio().playSound(2);
        else if (Input.GetKeyDown(KeyCode.Space))
            Locator.GetAudio().stopAllSound();
    }

    private void enableAudioLogging()
    {
        Audio_soli service = new LoggedAudio_soli(Locator.GetAudio());
        Locator.provide(service);
    }
}
