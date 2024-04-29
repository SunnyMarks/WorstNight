using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Battery : MonoBehaviour, IInteractable
{
    public Player_SO PlayerSO;
    public SFX_SO batteriesPickup;

    public static Action batteryCollectedEvent;
    public void Interact()
    {
        PlayerSO.batteries += 1;
        batteriesPickup.Play(AudioManager.instance.effectsSource);
        batteryCollectedEvent?.Invoke();
        Destroy(gameObject);
    }
}
