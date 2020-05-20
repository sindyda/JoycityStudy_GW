using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMS_EventQueuePattern : MonoBehaviour
{
    KMS_Audio kmsAudio = new KMS_Audio();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            kmsAudio.PlaySound(kmsAudio.currentID, kmsAudio.currentVolume);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            kmsAudio.StartEventQueue();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            --kmsAudio.currentID;
            if (kmsAudio.currentID < 0)
                kmsAudio.currentID = 0;

            Debug.Log("Current ID = " + kmsAudio.currentID);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ++kmsAudio.currentID;

            Debug.Log("Current ID = " + kmsAudio.currentID);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            kmsAudio.currentVolume += 10;

            if (kmsAudio.currentVolume > 100)
                kmsAudio.currentVolume = 0;

            Debug.Log("Current Volume = " + kmsAudio.currentVolume);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            kmsAudio.currentVolume -= 10;

            if (kmsAudio.currentVolume < 0)
                kmsAudio.currentVolume = 0;

            Debug.Log("Current Volume = " + kmsAudio.currentVolume);
        }
    }
}
