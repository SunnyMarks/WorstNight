using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound2D : MonoBehaviour
{
    public SFX_SO normalFootsteps;

    public AudioSource audioSource;

    public void PlayFootstepSound()
    {
        if (normalFootsteps != null)
        {
            if (audioSource != null)
            {
                normalFootsteps.Play(audioSource);
            }
            else
            {
                normalFootsteps.Play(AudioManager.instance.effectsSource);
            }
            
        }
    }
}
