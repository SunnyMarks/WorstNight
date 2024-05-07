using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinalDoor : MonoBehaviour, IInteractable
{
    public Player_SO player;

    public static Action FinalDoorOpenedEvent;
    
    public void Interact()
    {
        if (player.keys > 0)
        {
            player.isTransforming = true;
            FinalDoorOpenedEvent?.Invoke();
        }
    }


}
