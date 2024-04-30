using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] Player_SO player;
    [SerializeField] private LayerMask layerMask;

    CapsuleCollider cC;
    Light l;

    //bool isFlashLightOn;
    //public bool hasFlashLight;

    [SerializeField] float maxCharge;
    //[SerializeField] float charge;
    [SerializeField] float drainAmount;
    [SerializeField] float batteryChargeAmount;

    [SerializeField] SFX_SO flashLightOn;
    [SerializeField] SFX_SO flashLightOff;

    public static Action batteryUsedEvent;
    public static Action batteryDrainedEvent;

    private void Start()
    {
        cC = GetComponentInChildren<CapsuleCollider>();
        l = gameObject.GetComponent<Light>();

        l.enabled = false;
        //cC.enabled = false;
        Cursor.visible = false;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
        {
            // Get the direction to the hit point
            Vector3 targetDirection = hit.point - transform.position;
            targetDirection.y = 0f; // Optional: Keep the rotation only in the horizontal plane

            // Rotate towards the hit point
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashLight();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UseBattery();
        }

        DrainCharge();
    }

    void ToggleFlashLight()
    {
        if (player.hasFlashLight)
        {
            if (player.isFlashLightOn)
            {
                //cC.enabled = false;
                l.enabled = false;
                player.isFlashLightOn = false;
                flashLightOff.Play(AudioManager.instance.effectsSource);
            }
            else if (!player.isFlashLightOn && player.charge > 0)
            {
                //cC.enabled = true;
                l.enabled = true;
                player.isFlashLightOn = true;
                flashLightOn.Play(AudioManager.instance.effectsSource);
            }
        }
    }

    void DrainCharge()
    {
        if (player.isFlashLightOn)
        {
            player.charge -= drainAmount * Time.deltaTime;
            player.charge = Mathf.Clamp(player.charge, 0, 100);
            batteryDrainedEvent?.Invoke();
            if (player.charge <= 0)
            {
                cC.enabled = false;
                l.enabled = false;
                player.isFlashLightOn = false;
                flashLightOff.Play(AudioManager.instance.effectsSource);
            }
        }


    }

    void UseBattery()
    {
        if (player.batteries > 0)
        {
            player.charge += batteryChargeAmount;
            player.batteries -= 1;
            batteryUsedEvent?.Invoke();
        }

    }
}
