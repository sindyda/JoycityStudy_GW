using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNE : MonoBehaviour
{
    class Locator
    {
        private static Locator _instance;
        private UNE_Audio _service;

        public static Locator Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new Locator();
                return _instance;
            }
        }

        public UNE_Audio GetAudio() { return _service; }
        public void Provide(UNE_Audio service)
        {
            if (null == service)
            {
                _service = new UNE_NullAudio();
            }
            else
            {
                _service = service;
            }
        }

    }

    #region Audio
    public class UNE_Audio
    {
        public virtual void PlaySound(int soundID) { }
        public virtual void StopSound(int soundID) { }
    }
    public class UNE_NullAudio : UNE_Audio
    {
        public override void PlaySound(int soundID) { /* 아무 것도 하지 않는다. */ }
        public override void StopSound(int soundID) { /* 아무 것도 하지 않는다. */ }
    }
    public class UNE_UnityAudio : UNE_Audio
    {
        public AudioSource _audioSource = null;
        public List<AudioClip> _audioClips = new List<AudioClip>();
        public UNE_UnityAudio(AudioSource aSource, List<AudioClip> aClips)
        {
            _audioSource = aSource;
            _audioClips = aClips;
        }
        public override void PlaySound(int soundID)
        {
            var adjustSoundID = soundID - 1;
            base.PlaySound(soundID);
            if (_audioSource != null)
            {
                if (0 <= adjustSoundID && adjustSoundID < _audioClips.Count)
                {
                    _audioSource.clip = _audioClips[adjustSoundID];
                    _audioSource.Stop();
                    _audioSource.Play();
                }
            }
        }
        public override void StopSound(int soundID)
        {
            base.StopSound(soundID);
            if (_audioSource != null)
            {
                _audioSource.Stop();
            }
        }
    }
    public class UNE_LoggedAudio : UNE_Audio
    {
        private UNE_Audio _wrapped;
        public UNE_LoggedAudio(UNE_Audio audio)
        {
            _wrapped = audio;
        }
        public override void PlaySound(int soundID)
        {
            base.PlaySound(soundID);
            Debug.Log("사운드를 출력합니다. " + soundID);
            _wrapped?.PlaySound(soundID);
        }
        public override void StopSound(int soundID)
        {
            base.StopSound(soundID);
            Debug.Log("사운드를 중지합니다. " + soundID);
            _wrapped?.StopSound(soundID);
        }
    }

    #endregion Audio

    [SerializeField] AudioSource aSource;
    [SerializeField] List<AudioClip> aClips;

    // Start is called before the first frame update
    void Start()
    {
        Locator.Instance?.Provide(new UNE_UnityAudio(aSource, aClips));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Locator.Instance?.Provide(new UNE_LoggedAudio(Locator.Instance?.GetAudio()));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Locator.Instance?.Provide(new UNE_UnityAudio(aSource, aClips));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Locator.Instance?.GetAudio()?.PlaySound(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Locator.Instance?.GetAudio()?.PlaySound(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Locator.Instance?.GetAudio()?.PlaySound(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Locator.Instance?.GetAudio()?.PlaySound(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Locator.Instance?.GetAudio()?.PlaySound(5);
        }
    }
}
