using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour, IInteractable
{
    

    public Player_SO player;

    public static Action DoorOpenedEvent;

    //Transform playerTransform;

    public void Interact()
    {
       if(player.keys > 0)
        {
            Debug.Log("Opening Door");
            DoorOpenedEvent?.Invoke();
            player.keys--;
            Destroy(gameObject);
        }
    }


}
