using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct PlayMessage_soli
{
    public int soundId_;
    public int volume_;
}

public class Audio_soli
{
    public static void init()
    {
        head_ = 0;
        tail_ = 0;
    }

    public static void playSound(int soundId, int volume)
    {
        for (int i = head_; i != tail_; i = (i + 1) % MAX_PENDING)
        {
            if(pending_[i].soundId_ == soundId)
            {
                pending_[i].volume_ = Mathf.Max(pending_[i].volume_, volume);
                return;
            }
        }

        if((tail_ + 1) % MAX_PENDING == head_)
            return;

        pending_[tail_].soundId_ = soundId;
        pending_[tail_].volume_ = volume;
        tail_ = (tail_ + 1) % MAX_PENDING;
    }

    public static void update()
    {
        if (head_ == tail_)
            return;

        string resource = loadSound(pending_[head_].soundId_);
        int channel = findOpenChannel();
        if (channel == -1)
            return;

        startSound(resource, channel, pending_[head_].volume_);
    }

    public static string loadSound(int soundId)
    {
        string resource = string.Empty;
        switch(soundId)
        {
            case 1:
                resource = "Click_A";
                break;
            case 2:
                resource = "Click_B";
                break;
        }
        return resource;
    }

    public static int findOpenChannel()
    {
        int channel = 0;
        return channel;
    }

    public static void startSound(string resource, int channel, int volume)
    {
        var r = GameObject.Find(resource);
        if (r)
        {
            var c = r.GetComponent<AudioSource>();
            if (c)
            {
                c.volume = volume / 100f;
                c.Play();
            }
        }
    }
    
    private const int MAX_PENDING = 16;
    private static PlayMessage_soli[] pending_ = new PlayMessage_soli[MAX_PENDING];
    private static int head_;
    private static int tail_;
}
