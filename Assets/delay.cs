using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip whispers;
    void Start()
    {
        audioSource.PlayDelayed(10);
        //StartCoroutine(playdelay());
        StartCoroutine(PlaySoundRandomly());
    }


    IEnumerator playdelay()
    {
        yield return new WaitForSeconds(15);
        audioSource.PlayOneShot(whispers);
    }

    public AudioClip[] sounds;
    public float minInterval = 60f;
    public float maxInterval = 120f;

    IEnumerator PlaySoundRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
            PlayRandomSound();
        }
    }

    void PlayRandomSound()
    {
        if (sounds.Length == 0)
        {
            Debug.LogWarning("No sounds assigned to RandomSoundPlayer.");
            return;
        }

        AudioClip randomClip = sounds[Random.Range(0, sounds.Length)];
        audioSource.PlayOneShot(randomClip);
    }
}
