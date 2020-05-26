using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_ServiceProviderPattern : MonoBehaviour
{
    List<KMS_Audio> audioList = new List<KMS_Audio>();
    int currentNumber = 0;

    private void Start()
    {
        KMS_Locator.Init();

        ConsoleAudio consoleAudio = new ConsoleAudio();
        LogAudio logAudio = new LogAudio();

        audioList.Add(consoleAudio);
        audioList.Add(logAudio);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            KMS_Locator.Provide(audioList[currentNumber++]);
            if (currentNumber >= audioList.Count)
                currentNumber = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            KMS_Locator.Provide(audioList[currentNumber--]);
            if (currentNumber < 0)
                currentNumber = audioList.Count - 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            KMS_Locator.GetAudio().PlaySound(0);
        }
    }
}
