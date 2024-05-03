using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamagePlayer : MonoBehaviour, IDamager
{
    [SerializeField] private Player_SO player;

    [SerializeField] float damageAmount;

    [SerializeField] AIBehavior aIBehavior;
    [SerializeField] AIBehavior1 aIBehavior1;

    public static Action PlayerDamagedEvent;
    public void DoDamage()
    {
        if(player.isTransforming)
        {
            return;
        }

        aIBehavior?.DamageAnimation();
        aIBehavior1?.DamageAnimation();
        player.health -= damageAmount;
        
        Debug.Log(player.health);
        PlayerDamagedEvent?.Invoke();
    }
}
