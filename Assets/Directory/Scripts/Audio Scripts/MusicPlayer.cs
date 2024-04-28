using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    AudioSource source;

    [SerializeField] private SFX_SO music;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = music.clips[0].clip;
        source.volume = music.clips[0].volume;
        //source.Play();
    }

    [ContextMenu("ApplyVolume")]
    public void ApplyVolume()
    {
        source.volume = music.clips[0].volume;
    }
}
