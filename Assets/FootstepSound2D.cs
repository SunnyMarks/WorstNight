using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound2D : MonoBehaviour
{
    public SFX_SO normalFootsteps;

    public void PlayFootstepSound()
    {
        if (normalFootsteps != null)
        {
            normalFootsteps.Play(AudioManager.instance.effectsSource);
        }
    }
}
