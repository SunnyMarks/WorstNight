using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] public AudioSource musicSource, effectsSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        effectsSource.PlayOneShot(clip, volume);
    }

}
