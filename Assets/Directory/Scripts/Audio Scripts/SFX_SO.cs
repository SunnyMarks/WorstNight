using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClip", menuName = "ScriptableObject/AudioClip")]
public class SFX_SO : ScriptableObject
{
    //public AudioClip clip;
    //[Range(0, 1f)]
    //public float volume = 1;

    [SerializeField] public Clip[] clips;

    public void Play(AudioSource audioSource)
    {
        audioSource.PlayOneShot(clips[0].clip, clips[0].volume);
    }

    public void PlayRandom(AudioSource audioSource)
    {
        Clip clip = clips[Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(clip.clip, clip.volume);
    }
}

[System.Serializable] public class Clip
{
    public AudioClip clip;
    [Range(0, 1f)]
    public float volume = 1;


}