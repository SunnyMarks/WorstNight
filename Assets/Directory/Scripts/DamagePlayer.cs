using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamagePlayer : MonoBehaviour, IDamager
{
    [SerializeField] private Player_SO player;
    [SerializeField] private SFX_SO damageSound;
    [SerializeField] private SFX_SO LaughSound;

    [SerializeField] float damageAmount;

    [SerializeField] AIBehavior aIBehavior;
    [SerializeField] AIBehavior1 aIBehavior1;

    public static Action PlayerDamagedEvent;

    [SerializeField] AudioSource audioSource;
    public void DoDamage()
    {
        if(player.isTransforming)
        {
            return;
        }
        LaughSound?.PlayRandom(audioSource);

        aIBehavior?.DamageAnimation();
        aIBehavior1?.DamageAnimation();
        player.health -= damageAmount;
        
        Debug.Log(player.health);
        damageSound.Play(AudioManager.instance.effectsSource);
        PlayerDamagedEvent?.Invoke();
    }
}
