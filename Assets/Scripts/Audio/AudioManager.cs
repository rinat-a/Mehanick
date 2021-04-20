using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager S;

    [SerializeField, Range(0f, 1f)]
    float volume;
    float lastVolume = -1f;

    [SerializeField] Audio[] audios;
    
    private void Awake()
    {
        if (S == null)  S = this;
        else            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
        foreach (Audio s in audios)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }
    }

    private void Update()
    {
        if (lastVolume != volume)
        {
            foreach (Audio s in audios)
            {
                s.source.volume = s.volume * volume;
            }
            lastVolume = volume;
        }
        /*
        if (Game.S != null) 
        {
            if (Game.S.isPause)
            {
                foreach (Audio s in audios)
                {
                    if (s.source.isPlaying)
                        s.source.Pause();
                }
            }
            else
            {
                foreach (Audio s in audios)
                {
                    if (!s.source.isPlaying)
                        s.source.UnPause();
                }
            }
        }
        */

    }

    private void Start()
    {
        //S.Play("BackgroundMusic");
    }

    public void Stop(string name)
    {
        Audio s = Array.Find(audios, audio => audio.name == name);
        if (s == null)
        {
            Debug.LogWarningFormat("Audio {0} not found!", name);
            return;
        }
        s.source.Stop();
    }

    public void Play(string name)
    {
        Audio s = Array.Find(audios, audio => audio.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio " + name + " not found!");
            return;
        }
        s.source.Play();
    }

}
