using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayMessage
{
    public int id;
    public int volume;
}

public class KMS_Audio
{
    public const int MAX_PENDING = 10;

    public int head = 0;
    public int tail = 0;
    public PlayMessage[] pending = new PlayMessage[MAX_PENDING];

    public int currentID = 0;
    public int currentVolume = 0;

    public void PlaySound(int id, int volume)
    {
        if ((tail + 1) % MAX_PENDING != head)
        {
            pending[tail].id = id;
            pending[tail].volume = volume;

            tail = (tail + 1) % MAX_PENDING;
            Debug.Log("이벤트 입력 : " + id + "," + volume);
        }
        else
        {
            Debug.LogError("Queue is full.");
        }
    }

    public void StartEventQueue()
    {
        if (head == tail)
        {
            Debug.Log("출력할 사운드가 없습니다");
            return;
        }


        Debug.Log(string.Format("{0}사운드를 {1}볼륨으로 플레이", pending[head].id, pending[head].volume));
        head = (head + 1) % MAX_PENDING;
    }
}
