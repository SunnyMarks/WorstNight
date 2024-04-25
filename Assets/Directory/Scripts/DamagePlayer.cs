using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour, IDamager
{
    [SerializeField] private Player_SO player;

    [SerializeField] float damageAmount;

    [SerializeField] AIBehavior aIBehavior;
    [SerializeField] AIBehavior1 aIBehavior1;
    public void DoDamage()
    {
        aIBehavior?.DamageAnimation();
        aIBehavior1?.DamageAnimation();
        player.health -= damageAmount;
        Debug.Log(player.health);
    }
}
