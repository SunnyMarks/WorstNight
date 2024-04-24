using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Player")]
public class Player_SO : ScriptableObject
{
    public float health;
    public int batteries;
    public int keys;
    public bool isSprinting;
    public float stamina = 100;
    public bool canMove;
    public bool isFlashLightOn;
    public bool hasFlashLight;
    // conditionState



    void OnEnable()
    {
        health = 100;
        Debug.Log(health);
        batteries = 0;
        stamina = 100;
        canMove = true;
    }
    
}
