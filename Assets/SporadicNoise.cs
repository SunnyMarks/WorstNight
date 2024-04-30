using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporadicNoise : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] sounds;
    public float minInterval = 60f;
    public float maxInterval = 120f;
    void Start()
    {
        audioSource.PlayDelayed(10);
        StartCoroutine(PlaySoundRandomly());
    }

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
        audioSource.panStereo = Random.Range(-1, 2);
        audioSource.PlayOneShot(randomClip);
    }
}
